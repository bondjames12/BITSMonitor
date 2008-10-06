using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace BitsMonitor
{
	public partial class mListView : ListView
	{
		private SortOrder _actualSortOrder;
		private int _actualSortColumn;
		private bool _sortingPerformed = false;

		public mListView()
		{
			InitializeComponent();
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		}

		private void mListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (!_sortingPerformed || ( e.Column != _actualSortColumn ) )
			{
				this.ListViewItemSorter = new mListComparer(e.Column);
			}
			else
			{
				bool reverse = ( _actualSortOrder == SortOrder.Ascending );
				this.ListViewItemSorter = new mListComparer(e.Column, reverse);
			}

			_sortingPerformed = true;
			_actualSortColumn = e.Column;
			_actualSortOrder = SortOrder.Ascending;
		}
	}

	internal class mListComparer : IComparer
	{
		private int _sortColumn = 0;
		private bool _reverse = false;

		public mListComparer()
		{
		}

		public mListComparer(int sortColumn)
		{
			_sortColumn = sortColumn;
		}

		public mListComparer(int sortColumn, bool reverse)
		{
			_sortColumn = sortColumn;
			_reverse = reverse;
		}


		#region IComparer Members

		public int Compare(object x, object y)
		{
				int sortOrder = string.Compare(((ListViewItem)x).SubItems[_sortColumn].Text, ((ListViewItem)y).SubItems[_sortColumn].Text);
				return (_reverse == false) ? sortOrder : sortOrder * -1;
		}

		#endregion
	}
}
