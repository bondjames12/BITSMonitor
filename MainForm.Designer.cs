﻿namespace BitsMonitor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("{ \"url\", \"job\", \"%\" }");
			this.toolStripMenu = new System.Windows.Forms.ToolStrip();
			this.tsbAddJob = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbStart = new System.Windows.Forms.ToolStripButton();
			this.tsbSuspend = new System.Windows.Forms.ToolStripButton();
			this.tsbComplete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCancel = new System.Windows.Forms.ToolStripButton();
			this.btnAbout = new System.Windows.Forms.ToolStripButton();
			this.lstDownloads = new System.Windows.Forms.ListView();
			this.FileNameColumn = new System.Windows.Forms.ColumnHeader();
			this.JobColumn = new System.Windows.Forms.ColumnHeader();
			this.PercentColumn = new System.Windows.Forms.ColumnHeader();
			this.jobStateColumn = new System.Windows.Forms.ColumnHeader();
			this.UrlColumn = new System.Windows.Forms.ColumnHeader();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiStart = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiPause = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmiComplete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiCancel = new System.Windows.Forms.ToolStripMenuItem();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.applicationContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiRestoreMinimize = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenu.SuspendLayout();
			this.contextMenu.SuspendLayout();
			this.applicationContextMenu.SuspendLayout();
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
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
			this.btnAbout.Size = new System.Drawing.Size(44, 22);
			this.btnAbout.Text = "About";
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
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
			this.lstDownloads.Size = new System.Drawing.Size(457, 239);
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
			this.PercentColumn.Text = "Complete";
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
			// tsmiCancel
			// 
			this.tsmiCancel.Image = global::BitsMonitor.Properties.Resources.delete3;
			this.tsmiCancel.ImageTransparentColor = System.Drawing.Color.White;
			this.tsmiCancel.Name = "tsmiCancel";
			this.tsmiCancel.Size = new System.Drawing.Size(158, 22);
			this.tsmiCancel.Text = "Cancel";
			this.tsmiCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.applicationContextMenu;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Bits Monitor";
			this.notifyIcon.Visible = true;
			this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
			this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
			this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
			// 
			// applicationContextMenu
			// 
			this.applicationContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRestoreMinimize,
            this.toolStripMenuItem1,
            this.tsmiExit});
			this.applicationContextMenu.Name = "applicationContextMenu";
			this.applicationContextMenu.ShowImageMargin = false;
			this.applicationContextMenu.Size = new System.Drawing.Size(149, 54);
			// 
			// tsmiRestoreMinimize
			// 
			this.tsmiRestoreMinimize.Name = "tsmiRestoreMinimize";
			this.tsmiRestoreMinimize.Size = new System.Drawing.Size(148, 22);
			this.tsmiRestoreMinimize.Text = "Restore / Minimize";
			this.tsmiRestoreMinimize.Click += new System.EventHandler(this.tsmiRestoreMinimize_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
			// 
			// tsmiExit
			// 
			this.tsmiExit.Name = "tsmiExit";
			this.tsmiExit.Size = new System.Drawing.Size(148, 22);
			this.tsmiExit.Text = "Exit";
			this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(457, 264);
			this.Controls.Add(this.lstDownloads);
			this.Controls.Add(this.toolStripMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Bits Monitor";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.toolStripMenu.ResumeLayout(false);
			this.toolStripMenu.PerformLayout();
			this.contextMenu.ResumeLayout(false);
			this.applicationContextMenu.ResumeLayout(false);
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
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.ToolStripButton btnAbout;
		private System.Windows.Forms.ToolStripButton tsbComplete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem tsmiComplete;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip applicationContextMenu;
		private System.Windows.Forms.ToolStripMenuItem tsmiRestoreMinimize;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem tsmiExit;
    }
}

