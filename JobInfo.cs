using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BitsNet;

namespace BitsMonitor
{
	public partial class JobInfo : Form
	{
		private BitsJob _job;

		public JobInfo( BitsJob j )
		{
			InitializeComponent();
			this._job = j;
			InitializeComponentEx();
		}

		private void InitializeComponentEx()
		{
			this.txtJobUrl.Text = _job.Url;
			this.txtJobName.Text = _job.DisplayName;
		}

		private void btn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void JobInfo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				this.Close();
		}
	}
}
