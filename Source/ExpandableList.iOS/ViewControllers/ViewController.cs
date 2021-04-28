using System;
using System.Collections.Generic;
using UIKit;

namespace ExpandableList.iOS
{
    public partial class ViewController : UITableViewController
	{
        readonly IReadOnlyList<LocationModel> _locationList;

		public ViewController(IntPtr handle) : base(handle)
		{
			Title = "Locations Around The World";

            _locationList = LocationModel.CreateLocationList();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

            LocationTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

			LocationTableView.Source = new LocationTableSource(_locationList);
		}
	}
}

