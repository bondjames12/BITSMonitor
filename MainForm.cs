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
using BitsMonitor.Properties;

namespace BitsMonitor
{
    public partial class MainForm : Form
    {
		private Dictionary<Guid, BitsJob> _bitsJobs;
		private bool _listFilled = false;
		private DateTime _lastRefresh;

		private string _lastResumedJob = string.Empty;
		private uint _resumeCount = 0;

        public MainForm()
        {
            InitializeComponent();
			InitializeGUI();
            RefreshJobs();
			EnableActionsFromGui(false);
			timer.Enabled = true;
        }

		private void InitializeGUI()
		{
		}

		private void ResetTimers()
		{
			this.timer.Enabled = true;
		}

		#region RefreshJobs

		private void RefreshJobs()
        {
			_bitsJobs = BitsManager.GetAllJobs();
			if (!_listFilled)
				FillList(_bitsJobs);
			else
				RefreshList(_bitsJobs);
			_lastRefresh = DateTime.Now;
		}

		private void FillList(Dictionary<Guid, BitsJob> jobs)
		{
			lstDownloads.Items.Clear();

			foreach (BitsJob j in jobs.Values)
			{
				AddBitsJob2List(j);
			}
			_listFilled = true;
		}

		private void AddBitsJob2List(BitsJob j)
		{
			ListViewItem lvi = new ListViewItem(j.GetHashCode().ToString());
			lvi.SubItems[0].Text = j.FileName;
			lvi.SubItems.AddRange(new string[] { j.DisplayName, j.PercentComplete.ToString("P2", CultureInfo.InvariantCulture), j.JobStateDescription, j.Url });
			lvi.Tag = j.Guid;
			lstDownloads.Items.Add(lvi);
		}

		private void CheckAndAddNewJobs( Dictionary<Guid,BitsJob> jobs )
		{
			if (jobs.Count == lstDownloads.Items.Count)
				return;
			if (jobs.Count < lstDownloads.Items.Count)
			{
				RemoveJobsFromList(jobs);
			}
			else
			{
				AddJobsToList(jobs);
			}
				
		}

		private void RemoveJobsFromList(Dictionary<Guid, BitsJob> jobs)
		{
			List<int> indices = new List<int>(lstDownloads.Items.Count);
			for (int i = 0; i < lstDownloads.Items.Count; i++)
			{
				Guid g = (Guid)lstDownloads.Items[i].Tag;
				if (!jobs.ContainsKey(g))
					indices.Add(i);
			}
			for (int i = indices.Count - 1; i >= 0; i--)
			{
				lstDownloads.Items.RemoveAt(indices[i]);
			}
		}

		private void AddJobsToList(Dictionary<Guid, BitsJob> jobs)
		{
			List<Guid> newGuids = new List<Guid>(jobs.Count);
			newGuids.AddRange(jobs.Keys);
			for (int i = 0; i < lstDownloads.Items.Count; i++)
			{
				Guid g = (Guid)lstDownloads.Items[i].Tag;
				if (newGuids.Contains(g))
					newGuids.Remove(g);
			}

			for (int i = 0; i < newGuids.Count; i++)
			{
				AddBitsJob2List(jobs[newGuids[i]]);
			}
		}

		private void RefreshList( Dictionary<Guid,BitsJob> jobs)
        {
			CheckAndAddNewJobs(jobs);

			for (int i = 0; i < lstDownloads.Items.Count; i++)
			{
				Guid g = (Guid)lstDownloads.Items[i].Tag;
				BitsJob j = jobs[g];
				lstDownloads.Items[i].SubItems[1] = new ListViewItem.ListViewSubItem(lstDownloads.Items[i], j.DisplayName);
				lstDownloads.Items[i].SubItems[2] = new ListViewItem.ListViewSubItem(lstDownloads.Items[i], j.PercentComplete.ToString("P2", CultureInfo.InvariantCulture));
				lstDownloads.Items[i].SubItems[3] = new ListViewItem.ListViewSubItem(lstDownloads.Items[i], j.JobStateDescription );
				lstDownloads.Items[i].SubItems[4] = new ListViewItem.ListViewSubItem(lstDownloads.Items[i], j.Url );

				ResumeOrCompleteJob(j, jobs.Count);
			}
        }

		private void ResumeOrCompleteJob(BitsJob job, int jobsCount)
		{
			switch (job.JobState)
			{
				case BitsJobState.TRANSIENT_ERROR:
					if (jobsCount == 1)
					{
						if (job.DisplayName != _lastResumedJob)
						{
							_lastResumedJob = job.DisplayName;
							_resumeCount = 0;
							job.ResumeJob();
						}
						else
						{
							_resumeCount++;
							if (_resumeCount == 3)
								notifyIcon.ShowBalloonTip(1000, "Eror!", "Error while downloading {0}. 3 retries already failed", ToolTipIcon.Error);
						}
					}
					break;

				case BitsJobState.TRANSFERRED:
					job.CompleteJob();
					notifyIcon.ShowBalloonTip(1000, "Download info", String.Format("Download of {0} completed", job.DisplayName), ToolTipIcon.Info);
					break;
			}
		}

#endregion

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

		#region perform JobActions (Add, Resume, Suspend, Complete, Cancel)

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

		#endregion

		#region Jobs status refreshing

		private void timer_Tick(object sender, EventArgs e)
		{
			RefreshJobs();
		}

		#endregion

		#region Save/Load Window State

		private void LoadSettings()
		{
			if (Settings.Default.WindowHeight == -1)
				this.Height = 300;
			else
				this.Height = Settings.Default.WindowHeight;

			if (Settings.Default.WindowWidth == -1)
				this.Width = 473;
			else
				this.Width = Settings.Default.WindowWidth;

			if (Settings.Default.WindowLocation == new Point(-1, -1))
				this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);
			else
				this.Location = Settings.Default.WindowLocation;

			if (string.IsNullOrEmpty(Settings.Default.ColumnsWidth))
				return;
			string[] columnWidthStrings = Settings.Default.ColumnsWidth.Split(';');
			for (int i = 0; i < lstDownloads.Columns.Count; i++)
			{
				int width = int.Parse(columnWidthStrings[i], CultureInfo.InvariantCulture);
				lstDownloads.Columns[i].Width = width;
			}

		}

		private void SaveSettings()
		{
			Settings.Default.WindowWidth = this.Width;
			Settings.Default.WindowHeight = this.Height;
			if ( ( this.Location.X != -32000 ) && ( this.Location.Y == -32000 ) )
				Settings.Default.WindowLocation = this.Location;
			StringBuilder sb = new StringBuilder();
			char delimiter = ';';
			for (int i = 0; i < lstDownloads.Columns.Count; i++)
			{
				sb.Append(lstDownloads.Columns[i].Width);
				sb.Append(delimiter);
			}
			Settings.Default.ColumnsWidth = sb.ToString();
			Settings.Default.Save();
			
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			LoadSettings();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveSettings();
		}

		#endregion

		#region notify icon

		private void tsmiRestoreMinimize_Click(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Maximized || this.WindowState == FormWindowState.Normal)
			{
				this.WindowState = FormWindowState.Minimized;
			}
			else
			{
				this.WindowState = FormWindowState.Normal;
			}
		}

		private void tsmiExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
				this.ShowInTaskbar = false;
			else
				this.ShowInTaskbar = true;
		}

		private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			tsmiRestoreMinimize_Click(this, EventArgs.Empty);
		}

		#endregion

		private void btnAbout_Click(object sender, EventArgs e)
		{
			About about = new About();
			about.ShowDialog(this);
		}

		private BitsJob GetActiveJob()
		{
			BitsJob job = null;
			for (int i = 0; i < lstDownloads.Items.Count; i++)
			{
				string s = lstDownloads.Items[i].SubItems[3].Text;
				if (s.Contains("CONNE") || s.Contains("TRANSFERRING"))
				{
					job = BitsManager.GetAllJobs()[(Guid)lstDownloads.Items[i].Tag];
					break;
				}

			}
			return job;
		}

		private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				BitsJob job = GetActiveJob();
				if (job != null)
					notifyIcon.ShowBalloonTip(1000, "Download info", String.Format("job: {0} - {1}", job.DisplayName, job.PercentComplete.ToString("P2")), ToolTipIcon.Info);
			}
		}

		private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
				this.tsmiRestoreMinimize_Click(this, EventArgs.Empty);
		}

	}
}



