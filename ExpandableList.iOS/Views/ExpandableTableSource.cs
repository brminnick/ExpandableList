using System;
using System.Diagnostics;
using System.Collections.Generic;

using UIKit;
using Foundation;

namespace ExpandableList.iOS
{
	public abstract class ExpandableTableSource<T> : UITableViewSource where T : Chore, new()
	{
		#region Fields
		protected int _currentExpandedIndex = -1;
		protected int _totalExpandedRows;
		#endregion

		#region Properties
		public List<T> Items { get; set; }
		#endregion

		#region Methods
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true);

			if (IsChild(indexPath))
			{
				HandleChildSelected(tableView, indexPath);
				return;
			}

			tableView.BeginUpdates();
			if (_currentExpandedIndex == indexPath.Row)
			{
				CollapseSubItemsAtIndex(tableView, _currentExpandedIndex);
			}
			else
			{
				var numberOfExpandedRowsWhenTapped = _totalExpandedRows;
				var expandedRowIndexWhenTapped = _currentExpandedIndex;

				var shouldCollapse = _currentExpandedIndex > -1;

				if (shouldCollapse)
				{
					CollapseSubItemsAtIndex(tableView, expandedRowIndexWhenTapped);
					ExpandItemAtIndex(tableView, indexPath.Row - numberOfExpandedRowsWhenTapped);
				}
				else
				{
					ExpandItemAtIndex(tableView, indexPath.Row);
				}

			}
			tableView.EndUpdates();
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return Items.Count + ((_currentExpandedIndex > -1) ? 1 : 0);
		}

		protected bool IsChild(NSIndexPath indexPath)
		{
			return _currentExpandedIndex > -1 &&
				   indexPath.Row > _currentExpandedIndex &&
				   indexPath.Row <= _currentExpandedIndex + _totalExpandedRows;
		}

		void HandleChildSelected(UITableView tableView, NSIndexPath indexPath)
		{
			Debug.WriteLine("Child Row Selected");
			tableView.DeselectRow(indexPath, true);
		}

		void CollapseSubItemsAtIndex(UITableView tableView, int index)
		{
			var selectedItem = Items[index];
			if (selectedItem.Subchore == null)
				return;

			var currentIndex = index;
			foreach (T item in selectedItem.Subchore)
			{
				Items.Remove(item);
				tableView.DeleteRows(new[] { NSIndexPath.FromRowSection(++currentIndex, 0) }, UITableViewRowAnimation.Fade);
			}

			_currentExpandedIndex = -1;
			_totalExpandedRows = 0;
		}

		void ExpandItemAtIndex(UITableView tableView, int index)
		{
			var selectedItem = Items[index];
			if (selectedItem.Subchore == null)
				return;

			var currentIndex = index;
			foreach (T item in selectedItem.Subchore)
			{
				Items.Insert(++currentIndex, item);
				tableView.InsertRows(new[] { NSIndexPath.FromRowSection(currentIndex, 0) }, UITableViewRowAnimation.Fade);
				_totalExpandedRows++;
			}

			_currentExpandedIndex = index;
		}
		#endregion
	}
}
