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
            if (string.IsNullOrEmpty(this.txtJobName.Text) || string.IsNullOrEmpty(this.txtUrl.Text) || string.IsNullOrEmpty(this.txtSaveAs.Text))
            {
                if (string.IsNullOrEmpty(this.txtUrl.Text))
                    this.err.SetError(this.txtUrl, "no url specified");
                if (string.IsNullOrEmpty(this.txtJobName.Text))
                    this.err.SetError(this.txtJobName, "no job name specified");
				if (string.IsNullOrEmpty(this.txtSaveAs.Text))
					this.err.SetError(this.txtSaveAs, "no destination file specified");
            }
            else
            {
                if (!IsUrlOK())
                    this.err.SetError(this.txtUrl, "not proper web/ftp address");
				if (File.Exists(this.txtSaveAs.Text))
					this.err.SetError(this.txtSaveAs, "file already exists!");
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
    }
}
