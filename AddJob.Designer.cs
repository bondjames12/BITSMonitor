namespace BitsMonitor
{
    partial class AddJob
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.txtJobName = new System.Windows.Forms.TextBox();
			this.lblJobName = new System.Windows.Forms.Label();
			this.lblUrl = new System.Windows.Forms.Label();
			this.err = new System.Windows.Forms.ErrorProvider(this.components);
			this.cbxAutoRun = new System.Windows.Forms.CheckBox();
			this.txtSaveIn = new System.Windows.Forms.TextBox();
			this.lblSaveIn = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(217, 118);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(60, 23);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(151, 118);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(60, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtUrl
			// 
			this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtUrl.Location = new System.Drawing.Point(76, 12);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(201, 20);
			this.txtUrl.TabIndex = 1;
			// 
			// txtJobName
			// 
			this.txtJobName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtJobName.Location = new System.Drawing.Point(76, 38);
			this.txtJobName.Name = "txtJobName";
			this.txtJobName.Size = new System.Drawing.Size(201, 20);
			this.txtJobName.TabIndex = 3;
			// 
			// lblJobName
			// 
			this.lblJobName.AutoSize = true;
			this.lblJobName.Location = new System.Drawing.Point(9, 41);
			this.lblJobName.Name = "lblJobName";
			this.lblJobName.Size = new System.Drawing.Size(58, 13);
			this.lblJobName.TabIndex = 2;
			this.lblJobName.Text = "Job Name:";
			// 
			// lblUrl
			// 
			this.lblUrl.AutoSize = true;
			this.lblUrl.Location = new System.Drawing.Point(9, 15);
			this.lblUrl.Name = "lblUrl";
			this.lblUrl.Size = new System.Drawing.Size(23, 13);
			this.lblUrl.TabIndex = 0;
			this.lblUrl.Text = "Url:";
			// 
			// err
			// 
			this.err.ContainerControl = this;
			// 
			// cbxAutoRun
			// 
			this.cbxAutoRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbxAutoRun.AutoSize = true;
			this.cbxAutoRun.Location = new System.Drawing.Point(76, 95);
			this.cbxAutoRun.Name = "cbxAutoRun";
			this.cbxAutoRun.Size = new System.Drawing.Size(112, 17);
			this.cbxAutoRun.TabIndex = 4;
			this.cbxAutoRun.Text = "Autorun download";
			this.cbxAutoRun.UseVisualStyleBackColor = true;
			// 
			// txtSaveIn
			// 
			this.txtSaveIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSaveIn.Location = new System.Drawing.Point(76, 64);
			this.txtSaveIn.Name = "txtSaveIn";
			this.txtSaveIn.Size = new System.Drawing.Size(135, 20);
			this.txtSaveIn.TabIndex = 7;
			// 
			// lblSaveIn
			// 
			this.lblSaveIn.AutoSize = true;
			this.lblSaveIn.Location = new System.Drawing.Point(9, 68);
			this.lblSaveIn.Name = "lblSaveIn";
			this.lblSaveIn.Size = new System.Drawing.Size(46, 13);
			this.lblSaveIn.TabIndex = 8;
			this.lblSaveIn.Text = "Save in:";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(217, 63);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(60, 23);
			this.btnBrowse.TabIndex = 9;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// AddJob
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(294, 149);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.lblSaveIn);
			this.Controls.Add(this.txtSaveIn);
			this.Controls.Add(this.cbxAutoRun);
			this.Controls.Add(this.lblUrl);
			this.Controls.Add(this.lblJobName);
			this.Controls.Add(this.txtJobName);
			this.Controls.Add(this.txtUrl);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddJob";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AddJob";
			((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.CheckBox cbxAutoRun;
		private System.Windows.Forms.Label lblSaveIn;
		private System.Windows.Forms.TextBox txtSaveIn;
		private System.Windows.Forms.Button btnBrowse;
    }
}