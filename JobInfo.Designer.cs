namespace BitsMonitor
{
	partial class JobInfo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobInfo));
			this.lblJobName = new System.Windows.Forms.Label();
			this.lblUrl = new System.Windows.Forms.Label();
			this.txtJobName = new System.Windows.Forms.TextBox();
			this.txtJobUrl = new System.Windows.Forms.TextBox();
			this.btn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblJobName
			// 
			this.lblJobName.AutoSize = true;
			this.lblJobName.Location = new System.Drawing.Point(12, 15);
			this.lblJobName.Name = "lblJobName";
			this.lblJobName.Size = new System.Drawing.Size(58, 13);
			this.lblJobName.TabIndex = 0;
			this.lblJobName.Text = "Job Name:";
			// 
			// lblUrl
			// 
			this.lblUrl.AutoSize = true;
			this.lblUrl.Location = new System.Drawing.Point(12, 41);
			this.lblUrl.Name = "lblUrl";
			this.lblUrl.Size = new System.Drawing.Size(43, 13);
			this.lblUrl.TabIndex = 1;
			this.lblUrl.Text = "Job Url:";
			// 
			// txtJobName
			// 
			this.txtJobName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtJobName.Location = new System.Drawing.Point(102, 12);
			this.txtJobName.Name = "txtJobName";
			this.txtJobName.Size = new System.Drawing.Size(170, 20);
			this.txtJobName.TabIndex = 2;
			// 
			// txtJobUrl
			// 
			this.txtJobUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtJobUrl.Location = new System.Drawing.Point(102, 38);
			this.txtJobUrl.Name = "txtJobUrl";
			this.txtJobUrl.Size = new System.Drawing.Size(170, 20);
			this.txtJobUrl.TabIndex = 3;
			// 
			// btn
			// 
			this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn.Location = new System.Drawing.Point(197, 169);
			this.btn.Name = "btn";
			this.btn.Size = new System.Drawing.Size(75, 23);
			this.btn.TabIndex = 4;
			this.btn.Text = "OK";
			this.btn.UseVisualStyleBackColor = true;
			this.btn.Click += new System.EventHandler(this.btn_Click);
			// 
			// JobInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 200);
			this.Controls.Add(this.btn);
			this.Controls.Add(this.txtJobUrl);
			this.Controls.Add(this.txtJobName);
			this.Controls.Add(this.lblUrl);
			this.Controls.Add(this.lblJobName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "JobInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "JobInfo";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblJobName;
		private System.Windows.Forms.Label lblUrl;
		private System.Windows.Forms.TextBox txtJobName;
		private System.Windows.Forms.TextBox txtJobUrl;
		private System.Windows.Forms.Button btn;
	}
}