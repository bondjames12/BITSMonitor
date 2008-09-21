using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace BitsMonitor
{
    public partial class AddJob : Form
    {
        private Regex _regex;
        // simple pattern for checking if text is similar to proper ftp/http address
        private string urlPattern = @"^(http|ftp)://.+$";

        public string JobName
        {
            get { return this.txtJobName.Text; }
        }

        public string Url
        {
            get { return this.txtUrl.Text; }
        }

        
        public AddJob()
        {
            InitializeComponent();
            InitializeEx();
        }

        private void InitializeEx()
        {
            if (!Clipboard.ContainsText( TextDataFormat.Text | TextDataFormat.UnicodeText ))
                return;
            this.txtUrl.Text = Clipboard.GetText(TextDataFormat.Text | TextDataFormat.UnicodeText);
            this.txtUrl.Focus();
            this.txtUrl.Select();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.err.Clear();
            if (string.IsNullOrEmpty(this.txtJobName.Text) || string.IsNullOrEmpty(this.txtUrl.Text) || string.IsNullOrEmpty(this.txtSaveIn.Text))
            {
                if (string.IsNullOrEmpty(this.txtUrl.Text))
                    this.err.SetError(this.txtUrl, "no url specified");
                if (string.IsNullOrEmpty(this.txtJobName.Text))
                    this.err.SetError(this.txtJobName, "no job name specified");
				if (string.IsNullOrEmpty(this.txtSaveIn.Text))
					this.err.SetError(this.txtSaveIn, "no destination folder specified");
            }
            else
            {
                if (!IsUrlOK())
                    this.err.SetError(this.txtUrl, "not proper web/ftp address");
            }
        }

        /// <summary>
        /// very simple test if typed url seemes to be proper http/ftp address
        /// </summary>
        /// <returns></returns>
        private bool IsUrlOK()
        {
            if ( _regex == null )
                _regex = new Regex(urlPattern, RegexOptions.Compiled);
            return _regex.IsMatch(this.txtUrl.Text);
        }

		/// <summary>
		/// Browse for destination folder (folder where downloaded file will be stored)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowse = new FolderBrowserDialog();
			folderBrowse.ShowNewFolderButton = false;
			folderBrowse.Description = "Please choose destination folder for storing downloaded file";
			if (folderBrowse.ShowDialog() == DialogResult.OK)
			{
				this.txtSaveIn.Text = folderBrowse.SelectedPath;
			}
		}
    }
}
