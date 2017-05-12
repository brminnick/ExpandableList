using System;
using System.Linq;
using System.Collections.Generic;

using UIKit;
using Foundation;

using ExpandableList.Shared;

namespace ExpandableList.iOS
{
    public class ChoreTableSource : ExpandableTableSource<LocationModel>
    {
        #region Constant Fields
        const string _cellIdentifier = "taskcell";
        #endregion

        #region Constructors
        public ChoreTableSource(List<LocationModel> items)
        {
            Items = items.OrderBy(x => x.Continent).ThenBy(x => x.Name).ToList();
        }
        #endregion

        #region Methods
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(_cellIdentifier);

            var continentList = Items.Where(x => x.Continent == (ContinentType)indexPath.Section).ToList();

            cell.TextLabel.Text = continentList[indexPath.Row].Name;

            return cell;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return ((ContinentType)(int)section).ToString();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return Enum.GetNames(typeof(ContinentType)).Length;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Items.Count(x => x.Continent == ((ContinentType)(int)section));
        }

        #endregion
    }
}

