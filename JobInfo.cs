using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BitsMonitor
{
	public partial class JobInfo : Form
	{
		private bool _readOnly;
		public bool ReadOnly
		{
			get { return _readOnly; }
			set { _readOnly = value; }
		}

		public string JobName
		{
			get { return this.txtJobName.Text; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					this.txtJobName.Text = value;
			}
		}

		public string JobUrl
		{
			get { return this.txtJobUrl.Text; }
			set
			{
				if (!string.IsNullOrEmpty(value))
					this.txtJobUrl.Text = value;
			}
		}

		public JobInfo()
		{
			InitializeComponent();
		}

		protected void ReadOnlyChanged( )
		{
			foreach (Control c in this.Controls)
			{
				c.Enabled = _readOnly;
			}
		}

		private void btn_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
