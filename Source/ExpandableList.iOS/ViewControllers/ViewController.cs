using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using UIKit;

using ExpandableList.Shared;

namespace ExpandableList.iOS
{
	public partial class ViewController : UITableViewController
	{
        List<LocationModel> _locationList;

		public ViewController(IntPtr handle) : base(handle)
		{
			Title = "Locations Around The World";

            _locationList = LocationModel.CreateLocationList();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

            MasterView.SeparatorStyle = UITableViewCellSeparatorStyle.None;

			MasterView.Source = new LocationTableSource(_locationList);
		}
	}
}

