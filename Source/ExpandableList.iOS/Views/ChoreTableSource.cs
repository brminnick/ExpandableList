using System;
using System.Collections.Generic;

using UIKit;

using ExpandableList.Shared;

namespace ExpandableList.iOS
{
	public class ChoreTableSource : ExpandableTableSource<Chore>
	{
		#region Constant Fields
		const string _cellIdentifier = "taskcell";
		#endregion

		#region Constructors
		public ChoreTableSource(List<Chore> items)
		{
			Items = items;
		}
		#endregion

		#region Methods
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return Items.Count;
		}
		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(_cellIdentifier);

			cell.TextLabel.Text = Items[indexPath.Row].Name;
			if (Items[indexPath.Row].Done)
				cell.Accessory = UITableViewCellAccessory.Checkmark;
			else
				cell.Accessory = UITableViewCellAccessory.None;
			return cell;
		}

		public Chore GetItem(int id)
		{
			return Items[id];
		}
		#endregion
	}
}

