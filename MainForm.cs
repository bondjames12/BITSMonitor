using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Bits;
using BitsNet;
using System.Collections;
using System.Globalization;

namespace BitsMonitor
{
    public partial class MainForm : Form
    {
        private List<BitsJob> _bitsJobs;
		private TimeSpan _refreshInterval;
		private DateTime _lastRefresh;
		private string _lastTsmiClicked;

        public MainForm()
        {
            InitializeComponent();
			InitializeGUI();
            RefreshJobs();
			EnableActionsFromGui(false);
        }

		private void InitializeGUI()
		{
			this.tsddbRefreshInterval.DropDownItems[0].PerformClick();
		}

		private void ResetTimers()
		{
			this.timer.Enabled = true;
			this.timer.Interval = (int)_refreshInterval.TotalMilliseconds;
			this.timerRemaining.Enabled = true;
			this.timerRemaining.Interval = 1000;
			_lastRefresh = DateTime.Now;
		}

        private void RefreshJobs()
        {
            _bitsJobs = BitsManager.GetAllJobs();
            RefreshList(_bitsJobs);
			_lastRefresh = DateTime.Now;
		}

        private void RefreshList(List<BitsJob> jobs)
        {
            Cursor actual = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            this.lstDownloads.Items.Clear();

            foreach (BitsJob j in jobs)
            {
                ListViewItem lvi = new ListViewItem(j.GetHashCode().ToString());
                lvi.SubItems[0].Text = j.FileName;
                lvi.SubItems.AddRange(new string[] {j.DisplayName, j.PercentComplete.ToString("P2", CultureInfo.InvariantCulture), j.JobStateDescription, j.Url });
                lstDownloads.Items.Add(lvi);
				lvi.Tag = j.Guid;
            }

            Cursor.Current = actual;
        }

		private void lstDownloads_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			EnableActionsFromGui(IsJobSelected());
		}

		private void EnableActionsFromGui(bool state)
		{
			tsmiCancel.Enabled = state;
			tsmiStart.Enabled = state;
			tsmiPause.Enabled = state;
			tsmiComplete.Enabled = state;

			tsbCancel.Enabled = state;
			tsbSuspend.Enabled = state;
			tsbStart.Enabled = state;
			tsbComplete.Enabled = state;
		}

        private bool IsJobSelected()
        {
            return (lstDownloads.SelectedItems.Count > 0) ? true : false;
        }

		
		
		private Guid GetGuidFromListView(ListViewItem item)
		{
			return (Guid)item.Tag;
		}

		private Guid GetSelectedJobID()
		{
			return GetGuidFromListView(this.lstDownloads.SelectedItems[0]);
		}

		private List<Guid> GetSelectedJobGuids()
        {
            List<Guid> jobGuids = new List<Guid>();
            foreach (ListViewItem i in lstDownloads.SelectedItems)
            {
				jobGuids.Add((Guid)i.Tag);
            }
            return jobGuids;
		}

		#region perform Cancel,Resume,Complete on selected jobs...

		private void CancelJobs()
        {
			BitsManager.PerformActions(this.GetSelectedJobGuids(), BitsJobActions.CANCEL_JOB);
        }

        private void ResumeJobs()
        {
			BitsManager.PerformActions(GetSelectedJobGuids(), BitsJobActions.RESUME_JOB);
        }

		private void SuspendJobs()
		{
			BitsManager.PerformActions(GetSelectedJobGuids(), BitsJobActions.SUSPEND_JOB);
		}

        private void CompleteJobs()
        {
			BitsManager.PerformActions(this.GetSelectedJobGuids(), BitsJobActions.COMPLETE_JOB);
		}

		#endregion

		private void AddJob()
        {
            AddJob addjob = new AddJob();
            if (addjob.ShowDialog(this) == DialogResult.OK)
            {
				BitsManager.AddJob(addjob.Url, addjob.JobName, addjob.Directory);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
			ResumeJobs();
        }


		private void btnCancel_Click(object sender, EventArgs e)
		{
			CancelJobs();
		}

		private void btnSuspend_Click(object sender, EventArgs e)
		{
			SuspendJobs();
		}

		private void btnCompleteJob_Click(object sender, EventArgs e)
		{
			CompleteJobs();
		}

		private void tsbAddJob_Click(object sender, EventArgs e)
        {
            this.AddJob();
		}

		#region Jobs status refreshing

		private void tsddbRefreshInterval_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			ToolStripMenuItem tsmi = (ToolStripMenuItem)tsddbRefreshInterval.DropDownItems[e.ClickedItem.Name];
			if (tsmi.Checked)
				return;

			this.tsddbRefreshInterval.Text = tsmi.Text;
			if (!(tsmi.Tag is string))
			{
				MessageBox.Show( "Inproper value for autorefresh... 10s used!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error );
				_refreshInterval = new TimeSpan(0, 0, 10);
				return;
			}
			_refreshInterval = new TimeSpan( 0, 0, int.Parse( tsmi.Tag as string ) );
			if ( !string.IsNullOrEmpty( _lastTsmiClicked ) )
				(this.tsddbRefreshInterval.DropDownItems[_lastTsmiClicked] as ToolStripMenuItem).Checked = false;
			_lastTsmiClicked = tsmi.Name;
			tsmi.Checked = true;
			ResetTimers();
		}

		/// <summary>
		/// Refreshes the list of active (non completed) jobs.
		/// Preserves selection state of the jobs on the list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_Tick(object sender, EventArgs e)
		{
			EnableTimers(false);
			Cursor currentCursor = Cursor.Current;
			Cursor.Current = Cursors.WaitCursor;

			int indicesCount = lstDownloads.SelectedIndices.Count;
			int[] indices = new int[indicesCount];
			lstDownloads.SelectedIndices.CopyTo(indices, 0);

			RefreshJobs();

			for (int i = 0; i < indicesCount; i++)
			{
				lstDownloads.Items[indices[i]].Focused = true;
				lstDownloads.Items[indices[i]].Selected = true;
			}

			Cursor.Current = currentCursor;
			EnableTimers(true);
		}

		/// <summary>
		/// Enables/disables timers.
		/// </summary>
		/// <param name="state"></param>
		private void EnableTimers(bool state)
		{
			this.timer.Enabled = state;
			this.timerRemaining.Enabled = state;
		}

		private void timerRemaining_Tick(object sender, EventArgs e)
		{
			uint seconds = (uint)(DateTime.Now - _lastRefresh).TotalSeconds;
			this.lblSeconds.Text = ((uint)_refreshInterval.TotalSeconds -seconds).ToString();
		}
		#endregion

	}
}



