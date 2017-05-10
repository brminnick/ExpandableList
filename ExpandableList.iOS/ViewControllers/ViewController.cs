using System;
using System.Collections.Generic;

using UIKit;

namespace ExpandableList.iOS
{
	public partial class ViewController : UITableViewController
	{
		readonly List<Chore> _choreList;

		public ViewController(IntPtr handle) : base(handle)
		{
			Title = "Chore Board";

			_choreList = new List<Chore>();

			PopulateChoreList();
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			TableView.Source = new ChoreTableSource(_choreList);
		}

		void PopulateChoreList()
		{
			var groceriesDetails = new List<Chore>();
			groceriesDetails.Add(new Chore
			{
				Name = "Buy Milk"
			});
			groceriesDetails.Add(new Chore
			{
				Name = "Buy Bread"
			});

			var groceryChore = new Chore
			{
				Name = "Grocery Shopping",
				Done = false,
				Subchore = groceriesDetails
			};

			var carWashChore = new Chore
			{
				Name = "Car Wash"
			};

			_choreList.Add(groceryChore);
			_choreList.Add(carWashChore);
		}
	}
}

