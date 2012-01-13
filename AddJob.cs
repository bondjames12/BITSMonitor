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
using System.Security.Permissions;
using System.Security;
using BitsMonitor.Properties;

namespace BitsMonitor
{
    public partial class AddJob : Form
    {
        private Regex _regex;
        // simple pattern for checking if text is similar to proper ftp/http address
        private string urlPattern = @"^https?://.+$";

        public string JobName
        {
            get { return this.txtJobName.Text; }
        }

        public string Url
        {
            get { return this.txtUrl.Text; }
        }

        public string Directory
        {
            get { return this.txtSaveIn.Text; }
        }

        public bool AutoStartJob
        {
            get { return this.cbxAutoRun.Checked; }
            set { this.cbxAutoRun.Checked = value; }
        }

        private string recentlyUsedFolder;
        public string RecentlyUsedFolder
        {
            set { this.recentlyUsedFolder = value; }
        }
        
        public AddJob()
        {
            InitializeComponent();
            InitializeEx();
        }

        private void InitializeEx()
        {
            string mruDirectory = Settings.Default.MRUFolder;
            if (string.IsNullOrEmpty(mruDirectory))
            {
                mruDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            }
            if (!string.IsNullOrEmpty(mruDirectory) && (System.IO.Directory.Exists(mruDirectory)))
                this.txtSaveIn.Text = mruDirectory;
            else
                Settings.Default.MRUFolder = string.Empty;
            if (!Clipboard.ContainsText( TextDataFormat.Text | TextDataFormat.UnicodeText ))
                return;
            // check if clipboard text is a  valid link (starts with http or https)
            Regex urlregex = new Regex(urlPattern, RegexOptions.Compiled);
            string clipboardText = Clipboard.GetText(TextDataFormat.Text | TextDataFormat.UnicodeText);
            Match match = urlregex.Match(clipboardText);
            if (!match.Success)
                return;
            this.txtUrl.Text = clipboardText;
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
                {
                    this.err.SetError(this.txtUrl, "not proper web/ftp address");
                    return;
                }

                bool permission = true;
                FileInfo file = new FileInfo(Path.Combine(this.txtSaveIn.Text, this.txtJobName.Text));
                try
                {
                    using (Stream stream = file.OpenWrite())
                    {
                        stream.Close();
                        file.Delete();
                    }
                }
                catch
                {
                    permission = false;
                }
                if (permission == false)
                {
                    this.err.SetError(this.txtSaveIn, "no write permission");
                    return;
                }
            }
            Settings.Default.MRUFolder = this.txtSaveIn.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
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
            folderBrowse.ShowNewFolderButton = true;
            folderBrowse.Description = "Please choose destination folder for storing downloaded file";
            if (!string.IsNullOrEmpty(this.txtSaveIn.Text))
            {
                folderBrowse.SelectedPath = this.txtSaveIn.Text;
            }
            else if ( !string.IsNullOrEmpty(Settings.Default.MRUFolder))
            {
                folderBrowse.SelectedPath = Settings.Default.MRUFolder;
            }
            if (folderBrowse.ShowDialog() == DialogResult.OK)
            {
                this.txtSaveIn.Text = folderBrowse.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((this.txtUrl.Text)))
                return;
            int index = this.txtUrl.Text.LastIndexOf('/');
            if (index < 0)
                return;
            string newJobName = this.txtUrl.Text.Substring(index + 1);
            this.txtJobName.Text = newJobName;
        }
    }
}