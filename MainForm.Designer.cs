namespace BitsMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("{ \"url\", \"job\", \"%\" }");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStripMenu = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.lstDownloads = new System.Windows.Forms.ListView();
			this.FileNameColumn = new System.Windows.Forms.ColumnHeader();
			this.JobColumn = new System.Windows.Forms.ColumnHeader();
			this.PercentColumn = new System.Windows.Forms.ColumnHeader();
			this.jobStateColumn = new System.Windows.Forms.ColumnHeader();
			this.UrlColumn = new System.Windows.Forms.ColumnHeader();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblRefreshTime = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblSeconds = new System.Windows.Forms.ToolStripStatusLabel();
			this.lblSecondsRemaining = new System.Windows.Forms.ToolStripStatusLabel();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.timerRemaining = new System.Windows.Forms.Timer(this.components);
			this.tsmiComplete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiStart = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiPause = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbAddJob = new System.Windows.Forms.ToolStripButton();
			this.tsbStart = new System.Windows.Forms.ToolStripButton();
			this.tsbSuspend = new System.Windows.Forms.ToolStripButton();
			this.tsbComplete = new System.Windows.Forms.ToolStripButton();
			this.tsbCancel = new System.Windows.Forms.ToolStripButton();
			this.btnAbout = new System.Windows.Forms.ToolStripButton();
			this.tsddbRefreshInterval = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsmiTenSeconds = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiThirtySeconds = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiOneMinute = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenu.SuspendLayout();
			this.contextMenu.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStripMenu
			// 
			this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddJob,
            this.toolStripSeparator1,
            this.tsbStart,
            this.tsbSuspend,
            this.tsbComplete,
            this.toolStripSeparator2,
            this.tsbCancel,
            this.btnAbout});
			this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
			this.toolStripMenu.Name = "toolStripMenu";
			this.toolStripMenu.Size = new System.Drawing.Size(457, 25);
			this.toolStripMenu.TabIndex = 0;
			this.toolStripMenu.Text = "toolStrip1";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// lstDownloads
			// 
			this.lstDownloads.AllowColumnReorder = true;
			this.lstDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileNameColumn,
            this.JobColumn,
            this.PercentColumn,
            this.jobStateColumn,
            this.UrlColumn});
			this.lstDownloads.ContextMenuStrip = this.contextMenu;
			this.lstDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstDownloads.FullRowSelect = true;
			this.lstDownloads.GridLines = true;
			this.lstDownloads.HideSelection = false;
			listViewItem1.Checked = true;
			listViewItem1.StateImageIndex = 1;
			this.lstDownloads.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
			this.lstDownloads.Location = new System.Drawing.Point(0, 25);
			this.lstDownloads.Name = "lstDownloads";
			this.lstDownloads.Size = new System.Drawing.Size(457, 217);
			this.lstDownloads.TabIndex = 1;
			this.lstDownloads.UseCompatibleStateImageBehavior = false;
			this.lstDownloads.View = System.Windows.Forms.View.Details;
			this.lstDownloads.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstDownloads_ItemSelectionChanged);
			// 
			// FileNameColumn
			// 
			this.FileNameColumn.Text = "File Name";
			this.FileNameColumn.Width = 211;
			// 
			// JobColumn
			// 
			this.JobColumn.Text = "Job";
			// 
			// PercentColumn
			// 
			this.PercentColumn.Text = "%";
			this.PercentColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// jobStateColumn
			// 
			this.jobStateColumn.Text = "State";
			// 
			// UrlColumn
			// 
			this.UrlColumn.Text = "Url";
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStart,
            this.tsmiPause,
            this.tsmiComplete,
            this.toolStripMenuItem2,
            this.tsmiCancel});
			this.contextMenu.Name = "contextMenuStrip1";
			this.contextMenu.Size = new System.Drawing.Size(159, 98);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblRefreshTime,
            this.tsddbRefreshInterval,
            this.lblSeconds,
            this.lblSecondsRemaining});
			this.statusStrip1.Location = new System.Drawing.Point(0, 242);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(457, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblRefreshTime
			// 
			this.lblRefreshTime.Name = "lblRefreshTime";
			this.lblRefreshTime.Size = new System.Drawing.Size(106, 17);
			this.lblRefreshTime.Text = "Auto refresh every:";
			// 
			// lblSeconds
			// 
			this.lblSeconds.Name = "lblSeconds";
			this.lblSeconds.Size = new System.Drawing.Size(0, 17);
			// 
			// lblSecondsRemaining
			// 
			this.lblSecondsRemaining.Name = "lblSecondsRemaining";
			this.lblSecondsRemaining.Size = new System.Drawing.Size(113, 17);
			this.lblSecondsRemaining.Text = "  seconds remaining";
			// 
			// timer
			// 
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// timerRemaining
			// 
			this.timerRemaining.Tick += new System.EventHandler(this.timerRemaining_Tick);
			// 
			// tsmiComplete
			// 
			this.tsmiComplete.Image = global::BitsMonitor.Properties.Resources.complete;
			this.tsmiComplete.ImageTransparentColor = System.Drawing.Color.White;
			this.tsmiComplete.Name = "tsmiComplete";
			this.tsmiComplete.Size = new System.Drawing.Size(158, 22);
			this.tsmiComplete.Text = "Complete";
			this.tsmiComplete.Click += new System.EventHandler(this.btnCompleteJob_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(155, 6);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsmiStart
			// 
			this.tsmiStart.Image = global::BitsMonitor.Properties.Resources.Start;
			this.tsmiStart.ImageTransparentColor = System.Drawing.Color.White;
			this.tsmiStart.Name = "tsmiStart";
			this.tsmiStart.Size = new System.Drawing.Size(158, 22);
			this.tsmiStart.Text = "Start";
			this.tsmiStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// tsmiPause
			// 
			this.tsmiPause.Image = global::BitsMonitor.Properties.Resources.Pause;
			this.tsmiPause.ImageTransparentColor = System.Drawing.Color.White;
			this.tsmiPause.Name = "tsmiPause";
			this.tsmiPause.Size = new System.Drawing.Size(158, 22);
			this.tsmiPause.Text = "Pause / Resume";
			this.tsmiPause.Click += new System.EventHandler(this.btnSuspend_Click);
			// 
			// tsmiCancel
			// 
			this.tsmiCancel.Image = global::BitsMonitor.Properties.Resources.delete3;
			this.tsmiCancel.ImageTransparentColor = System.Drawing.Color.White;
			this.tsmiCancel.Name = "tsmiCancel";
			this.tsmiCancel.Size = new System.Drawing.Size(158, 22);
			this.tsmiCancel.Text = "Cancel";
			this.tsmiCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tsbAddJob
			// 
			this.tsbAddJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbAddJob.Image = global::BitsMonitor.Properties.Resources.Add;
			this.tsbAddJob.ImageTransparentColor = System.Drawing.Color.White;
			this.tsbAddJob.Name = "tsbAddJob";
			this.tsbAddJob.Size = new System.Drawing.Size(23, 22);
			this.tsbAddJob.Text = "Add new job";
			this.tsbAddJob.ToolTipText = "Shows dialog helpful with adding new job";
			this.tsbAddJob.Click += new System.EventHandler(this.tsbAddJob_Click);
			// 
			// tsbStart
			// 
			this.tsbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbStart.Image = global::BitsMonitor.Properties.Resources.Start;
			this.tsbStart.ImageTransparentColor = System.Drawing.Color.White;
			this.tsbStart.Name = "tsbStart";
			this.tsbStart.Size = new System.Drawing.Size(23, 22);
			this.tsbStart.Text = "Start job";
			this.tsbStart.ToolTipText = "Starts job";
			this.tsbStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// tsbSuspend
			// 
			this.tsbSuspend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSuspend.Image = ((System.Drawing.Image)(resources.GetObject("tsbSuspend.Image")));
			this.tsbSuspend.ImageTransparentColor = System.Drawing.Color.White;
			this.tsbSuspend.Name = "tsbSuspend";
			this.tsbSuspend.Size = new System.Drawing.Size(23, 22);
			this.tsbSuspend.Text = "Suspend downloading";
			this.tsbSuspend.ToolTipText = "Suspends downloading of the specified job";
			this.tsbSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
			// 
			// tsbComplete
			// 
			this.tsbComplete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbComplete.Image = global::BitsMonitor.Properties.Resources.complete;
			this.tsbComplete.ImageTransparentColor = System.Drawing.Color.White;
			this.tsbComplete.Name = "tsbComplete";
			this.tsbComplete.Size = new System.Drawing.Size(23, 22);
			this.tsbComplete.Text = "Complete Job";
			this.tsbComplete.ToolTipText = "Completes Job";
			this.tsbComplete.Click += new System.EventHandler(this.btnCompleteJob_Click);
			// 
			// tsbCancel
			// 
			this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCancel.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancel.Image")));
			this.tsbCancel.ImageTransparentColor = System.Drawing.Color.White;
			this.tsbCancel.Name = "tsbCancel";
			this.tsbCancel.Size = new System.Drawing.Size(23, 22);
			this.tsbCancel.Text = "Remove job";
			this.tsbCancel.ToolTipText = "Removes job";
			this.tsbCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAbout
			// 
			this.btnAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
			this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(53, 22);
			this.btnAbout.Text = "About...";
			// 
			// tsddbRefreshInterval
			// 
			this.tsddbRefreshInterval.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsddbRefreshInterval.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTenSeconds,
            this.tsmiThirtySeconds,
            this.tsmiOneMinute});
			this.tsddbRefreshInterval.Image = ((System.Drawing.Image)(resources.GetObject("tsddbRefreshInterval.Image")));
			this.tsddbRefreshInterval.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsddbRefreshInterval.Name = "tsddbRefreshInterval";
			this.tsddbRefreshInterval.Size = new System.Drawing.Size(13, 20);
			this.tsddbRefreshInterval.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsddbRefreshInterval_DropDownItemClicked);
			// 
			// tsmiTenSeconds
			// 
			this.tsmiTenSeconds.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmiTenSeconds.Name = "tsmiTenSeconds";
			this.tsmiTenSeconds.Size = new System.Drawing.Size(132, 22);
			this.tsmiTenSeconds.Tag = "10";
			this.tsmiTenSeconds.Text = "10 seconds";
			// 
			// tsmiThirtySeconds
			// 
			this.tsmiThirtySeconds.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmiThirtySeconds.Name = "tsmiThirtySeconds";
			this.tsmiThirtySeconds.Size = new System.Drawing.Size(132, 22);
			this.tsmiThirtySeconds.Tag = "30";
			this.tsmiThirtySeconds.Text = "30 seconds";
			// 
			// tsmiOneMinute
			// 
			this.tsmiOneMinute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmiOneMinute.Name = "tsmiOneMinute";
			this.tsmiOneMinute.Size = new System.Drawing.Size(132, 22);
			this.tsmiOneMinute.Tag = "60";
			this.tsmiOneMinute.Text = "1 minute";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(457, 264);
			this.Controls.Add(this.lstDownloads);
			this.Controls.Add(this.toolStripMenu);
			this.Controls.Add(this.statusStrip1);
			this.Name = "MainForm";
			this.Text = "Bits Monitor";
			this.toolStripMenu.ResumeLayout(false);
			this.toolStripMenu.PerformLayout();
			this.contextMenu.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbStart;
        private System.Windows.Forms.ToolStripButton tsbSuspend;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.ListView lstDownloads;
        private System.Windows.Forms.ColumnHeader FileNameColumn;
        private System.Windows.Forms.ColumnHeader JobColumn;
        private System.Windows.Forms.ColumnHeader PercentColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiStart;
        private System.Windows.Forms.ToolStripMenuItem tsmiPause;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancel;
        private System.Windows.Forms.ColumnHeader UrlColumn;
        private System.Windows.Forms.ToolStripButton tsbAddJob;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader jobStateColumn;
        private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblRefreshTime;
		private System.Windows.Forms.ToolStripDropDownButton tsddbRefreshInterval;
		private System.Windows.Forms.ToolStripMenuItem tsmiThirtySeconds;
		private System.Windows.Forms.ToolStripMenuItem tsmiOneMinute;
		private System.Windows.Forms.ToolStripMenuItem tsmiTenSeconds;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.ToolStripStatusLabel lblSeconds;
		private System.Windows.Forms.ToolStripStatusLabel lblSecondsRemaining;
		private System.Windows.Forms.Timer timerRemaining;
		private System.Windows.Forms.ToolStripButton btnAbout;
		private System.Windows.Forms.ToolStripButton tsbComplete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem tsmiComplete;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}

