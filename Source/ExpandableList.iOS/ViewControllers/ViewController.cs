using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using UIKit;

using ExpandableList.Shared;

namespace ExpandableList.iOS
{
	public partial class ViewController : UITableViewController
	{
		List<LocationModel> _choreList;

		public ViewController(IntPtr handle) : base(handle)
		{
			Title = "Locations Around The World";

            _choreList = LocationModel.CreateLocationList();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

			TableView.Source = new ChoreTableSource(_choreList);
		}
	}
}

