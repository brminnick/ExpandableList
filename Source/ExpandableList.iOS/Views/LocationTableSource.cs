using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace ExpandableList.iOS
{
    public class LocationTableSource : ExpandableTableSource<LocationModel>
    {
        const string _cellIdentifier = "taskcell";

        public LocationTableSource(IEnumerable<LocationModel> items)
            : base(items.OrderBy(x => x.Continent).ThenBy(x => x.Name))
        {

        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(_cellIdentifier);

            var continentList = Items.Where(x => x.Continent == (ContinentType)indexPath.Section).ToList();

            cell.TextLabel.Text = continentList[indexPath.Row].Name;

            return cell;
        }

        public override string TitleForHeader(UITableView tableView, nint section) =>
            ((ContinentType)(int)section).ToString();

        public override nint NumberOfSections(UITableView tableView) =>
            Enum.GetNames(typeof(ContinentType)).Length;

        public override nint RowsInSection(UITableView tableview, nint section) =>
            Items.Count(x => x.Continent == ((ContinentType)(int)section));
    }
}

