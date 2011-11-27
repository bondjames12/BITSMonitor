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
	public partial class ExceptionInfo : Form
	{
		public ExceptionInfo()
		{
			InitializeComponent();
			txtExceptionInfo.Focus();
		}

		public string UserProvidedInformation
		{
			get { return this.txtExceptionInfo.Text; }
		}

		private void btnDone_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
