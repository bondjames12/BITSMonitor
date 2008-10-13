using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace BitsMonitor
{
	[System.Drawing.ToolboxBitmap(typeof(System.Windows.Forms.CheckBox))]
	[ToolStripItemDesignerAvailability( ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip )]
	public partial class mToolStripCheckBox : ToolStripControlHost
	{
		public mToolStripCheckBox()
			: base(new System.Windows.Forms.CheckBox())
		{

		}

		public CheckBox CheckBox
		{
			get { return Control as CheckBox; }
		}

		public bool Checked
		{
			get { return (Control as CheckBox).Checked; }
			set { (Control as CheckBox).Checked = value; }
		}

		public CheckState CheckState
		{
			get { return (Control as CheckBox).CheckState; }
			set { (Control as CheckBox).CheckState = value; }
		}
	}
}
