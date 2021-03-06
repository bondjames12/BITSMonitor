﻿using System;
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
        private ActiveJobs _activeJobs;

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
            this.cbxActiveJobs.SelectedIndex = 0;
            this.cbxActiveJobs.SelectedIndexChanged += new EventHandler(cbxActiveJobs_SelectedIndexChanged);
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

            lvi.SubItems.AddRange(new string[] { j.DisplayName, j.PercentComplete.ToString("P2", CultureInfo.InvariantCulture), j.JobStateDescription, j.Url, (j.BytesTotal/1048576.0).ToString("N", CultureInfo.InvariantCulture), (j.BytesTransferred/1048576.0).ToString("N",CultureInfo.InvariantCulture) });
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
                if (lstDownloads.Items[i] == null)
                    continue;
                Guid g = (Guid)lstDownloads.Items[i].Tag;
                BitsJob j = jobs[g];
                lstDownloads.Items[i].SubItems[2] = new ListViewItem.ListViewSubItem(lstDownloads.Items[i], (j.PercentComplete).ToString("00.00 %", CultureInfo.InvariantCulture)); 
                lstDownloads.Items[i].SubItems[3] = new ListViewItem.ListViewSubItem(lstDownloads.Items[i], j.JobStateDescription);

                if (j.BytesTotal == ulong.MaxValue)
                        lstDownloads.Items[i].SubItems[5] = new ListViewItem.ListViewSubItem(lstDownloads.Items[i], "?");
                if ((lstDownloads.Items[i].SubItems[5].Text == "?") && (j.JobState == BitsJobState.TRANSFERRING))
                    lstDownloads.Items[i].SubItems[5] = new ListViewItem.ListViewSubItem(lstDownloads.Items[i], (j.BytesTotal / 1048576.0).ToString("N", CultureInfo.InvariantCulture));

                lstDownloads.Items[i].SubItems[6] = new ListViewItem.ListViewSubItem(lstDownloads.Items[i], (j.BytesTransferred/1048576.0).ToString("N",CultureInfo.InvariantCulture));
                if ( this.tsmiAutoRestart.Checked && ( ( j.JobState == BitsJobState.ERROR || ( j.JobState == BitsJobState.TRANSIENT_ERROR ) ) ) )
                    BitsManager.ResumeJob( j.Guid );
            }
            ColourJobs();
            AutoCompleteJobs();
            MakeFirstJobsActive();
            UpdateStatusInfo();
        }

        private void UpdateStatusInfo()
        {
            
            int active = 0;
            for (int i = 0; i < lstDownloads.Items.Count; i++)
            {
                Guid g = (Guid)lstDownloads.Items[i].Tag;
                if ( _bitsJobs[g].JobState == BitsJobState.TRANSFERRING || _bitsJobs[g].JobState == BitsJobState.QUEUED )
                    active++;
            }
            this.tsslActiveAllDownloads.Text = String.Format("active: {0} all: {1}", active, _bitsJobs.Count);
        }

        private void MakeFirstJobsActive()
        {
            if (_activeJobs == ActiveJobs.Manual)
                return;

            int activeJobsNum = 0;
            switch (_activeJobs)
            {
                case ActiveJobs.One:
                    activeJobsNum = 1;
                    break;
                case ActiveJobs.Three:
                    activeJobsNum = 3;
                    break;
                case ActiveJobs.Five:
                    activeJobsNum = 5;
                    break;
                case ActiveJobs.All:
                    activeJobsNum = lstDownloads.Items.Count;
                    break;
            }

            int counter = 0;
            for (int i = 0; i < lstDownloads.Items.Count; i++,counter++)
            {
                Guid g = (Guid)lstDownloads.Items[i].Tag;
                if (! _bitsJobs.ContainsKey(g) )
                    continue;
                
                BitsJob j = _bitsJobs[g];

                if ( (counter < activeJobsNum) && ( j.JobState != BitsJobState.TRANSFERRING && j.JobState!= BitsJobState.TRANSFERRED && j.JobState != BitsJobState.CONNECTING && j.JobState != BitsJobState.QUEUED ) )
                    BitsManager.ResumeJob(g);
                else
                {
                    if ( ( counter >= activeJobsNum ) && ( j.JobState != BitsJobState.SUSPENDED ) )
                        BitsManager.SuspendJob(g);
                }
            }
        }

        private void ColourJobs()
        {
            for (int i = 0; i < lstDownloads.Items.Count; i++)
            {
                Guid g = (Guid)lstDownloads.Items[i].Tag;
                if (!_bitsJobs.ContainsKey(g))
                    continue;
                switch (_bitsJobs[g].JobState)
                {
                    case BitsJobState.TRANSFERRING:
                        lstDownloads.Items[i].BackColor = Color.LightGreen;
                        break;
                    case BitsJobState.TRANSIENT_ERROR:
                        lstDownloads.Items[i].BackColor = Color.Coral;
                        break;
                    case BitsJobState.ERROR:
                        lstDownloads.Items[i].BackColor = Color.Coral;
                        break;
                    case BitsJobState.QUEUED:
                        lstDownloads.Items[i].BackColor = Color.LightSkyBlue;
                        break;
                    case BitsJobState.SUSPENDED:
                        lstDownloads.Items[i].BackColor = Color.Aquamarine;
                        break;
                    case BitsJobState.CONNECTING:
                        lstDownloads.Items[i].BackColor = Color.Lavender;
                        break;
                    default:
                        lstDownloads.Items[i].BackColor = Color.White;
                        break;
                }
            }
        }

        private void MakeAllJobsActive()
        {
            BitsManager.PerformActions(_bitsJobs.Keys.ToList<Guid>(), BitsJobActions.RESUME_JOB);
        }

        private void AutoCompleteJobs( )
        {
            for (int i = 0; i < lstDownloads.Items.Count; i++)
            {
                Guid g = (Guid)lstDownloads.Items[i].Tag;
                if (!_bitsJobs.ContainsKey(g))
                    continue;
                BitsJob j = _bitsJobs[g];
                if (j.JobState == BitsJobState.TRANSFERRED)
                {
                    notifyIcon.ShowBalloonTip(1000, "Download complete", String.Format("Downloading job: {0} finished", j.DisplayName), ToolTipIcon.Info);
                    BitsManager.CompleteJob(j.Guid);
                }
            }
            ShutdownWindows();
        }

        private void ShutdownWindows()
        {
            if (( lstDownloads.Items.Count != 0 ) || ( !cbxShutdown.Checked ) )
                return;

            WindowsFunc.ExitWindowsEx( (uint)ExitWindows.ShutDown, (uint)ShutdownReason.FlagUserDefined);
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

            tsbCancel.Enabled = state;
            tsbSuspend.Enabled = state;
            tsbStart.Enabled = state;

            // completing should be possible only for jobs that state is 'TRANSFERRED'
            bool completing = IsCompletingPossible();
            tsmiComplete.Enabled = completing;
            tsbComplete.Enabled = completing;
        }

        private bool IsCompletingPossible()
        {
            if (lstDownloads.SelectedItems.Count < 1)
                return false;
            // this will be very, very rare case...
            if (_bitsJobs.Count == 0)
                return false;

            Guid g;
            bool output = true;
            foreach (ListViewItem lvi in lstDownloads.SelectedItems)
            {
                g = (Guid)lvi.Tag;
                if (_bitsJobs[g].JobState != BitsJobState.TRANSFERRED)
                {
                    output = false;
                    break;
                }
            }
            return output;
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
            if ( MessageBox.Show( this, "Are you sure you want to cancel (delete) the job?", "Deleting the job...?", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
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
            addjob.AutoStartJob = this.tsmiAutoStart.Checked;
            if (addjob.ShowDialog(this) == DialogResult.OK)
            {
                BitsManager.AddJob(addjob.Url, addjob.JobName, addjob.Directory, addjob.AutoStartJob);
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
                if (string.IsNullOrEmpty(columnWidthStrings[i]))
                    continue;
                int width = int.Parse(columnWidthStrings[i], CultureInfo.InvariantCulture);
                lstDownloads.Columns[i].Width = width;
            }
            this.tsmiAutoRestart.Checked = Settings.Default.AutoRestartJobs;
            this.tsmiAutoStart.Checked = Settings.Default.AutoStartBitsJob;
            
            if (string.IsNullOrEmpty(Settings.Default.ActiveJobs))
                return;
            string[] activeJobsNames = Enum.GetNames(typeof(ActiveJobs));
            for (int i = 0; i < activeJobsNames.Length; i++)
            {
                if (activeJobsNames[i] == Settings.Default.ActiveJobs)
                {
                    this.cbxActiveJobs.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SaveSettings()
        {
            Settings.Default.WindowWidth = this.Width;
            Settings.Default.WindowHeight = this.Height;
            if ( ( this.Location.X != -32000 ) && ( this.Location.Y != -32000 ) )
                Settings.Default.WindowLocation = this.Location;
            StringBuilder sb = new StringBuilder();
            char delimiter = ';';
            for (int i = 0; i < lstDownloads.Columns.Count; i++)
            {
                sb.Append(lstDownloads.Columns[i].Width);
                sb.Append(delimiter);
            }
            Settings.Default.ColumnsWidth = sb.ToString();
            Settings.Default.AutoStartBitsJob = this.tsmiAutoStart.Checked;
            Settings.Default.AutoRestartJobs = this.tsmiAutoRestart.Checked;
            Settings.Default.ActiveJobs = cbxActiveJobs.SelectedItem.ToString();
            Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            // TODO: uncomment!
            //MakeAllJobsActive();
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
            BitsJob tempjob = null;
            Guid g;
            for (int i = 0; i < lstDownloads.Items.Count; i++)
            {
                g = (Guid)lstDownloads.Items[i].Tag;
                if (!_bitsJobs.ContainsKey(g))
                    continue;
                tempjob = _bitsJobs[g];
                if (tempjob.JobState == BitsJobState.CONNECTING || tempjob.JobState == BitsJobState.TRANSFERRING)
                {
                    job = tempjob;
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
                else
                    notifyIcon.ShowBalloonTip(1000, "Download info", "There are no active jobs", ToolTipIcon.Info);
            }
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.tsmiRestoreMinimize_Click(this, EventArgs.Empty);
            else
                this.Activate();
        }

        private void lstDownloads_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                for (int i = 0; i < lstDownloads.Items.Count; i++)
                {
                    lstDownloads.Items[i].Selected = true;
                }
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        if (tsbCancel.Enabled)
                            btnCancel_Click(this, EventArgs.Empty);
                        break;
                    case Keys.Space:
                        if (tsbSuspend.Enabled)
                            btnSuspend_Click(this, EventArgs.Empty);
                        break;
                }
            }
        }

        private void lstDownloads_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Guid g = (Guid)lstDownloads.GetItemAt(e.X, e.Y).Tag;

            BitsJob j = _bitsJobs[g];
            JobInfo jobInfo = new JobInfo(j);
            jobInfo.ShowDialog(this);
        }

        private void cbxActiveJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            _activeJobs = (ActiveJobs)Enum.Parse( typeof(ActiveJobs) , this.cbxActiveJobs.SelectedItem.ToString());
        }

    }

    public enum ActiveJobs
    {
        Manual,
        One,
        Three,
        Five,
        All
    }

}



