﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Foundation;
using UIKit;

namespace ExpandableList.iOS
{
    public abstract class ExpandableTableSource<T> : UITableViewSource where T : ExpandableListModel
    {
        protected int _currentExpandedRowIndex = -1;
        protected int _currentExpandedSectionIndex = -1;
        protected int _totalExpandedRows;
        protected T? _expandedCellSource;

        protected ExpandableTableSource(IEnumerable<T> items) => Items = items.ToList();

        protected List<T> Items { get; }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);

            if (IsChild(indexPath))
            {
                HandleChildSelected(tableView, indexPath);
                return;
            }

            tableView.BeginUpdates();
            if (_currentExpandedRowIndex == indexPath.Row && _currentExpandedSectionIndex == indexPath.Section)
            {
                CollapseSubItems(tableView);
            }
            else
            {
                var numberOfExpandedRowsWhenTapped = _totalExpandedRows;
                var expandedRowIndexWhenTapped = _currentExpandedRowIndex;
                var expandedSectionIndexWhenTapped = _currentExpandedSectionIndex;

                var shouldCollapse = _currentExpandedRowIndex > -1 && _currentExpandedSectionIndex > -1;

                if (shouldCollapse)
                {
                    CollapseSubItems(tableView);
                    ExpandItemAtIndex(tableView,
                                      indexPath,
                                      numberOfExpandedRowsWhenTapped,
                                      expandedRowIndexWhenTapped,
                                      expandedSectionIndexWhenTapped);
                }
                else
                {
                    ExpandItemAtIndex(tableView, indexPath);
                }

            }
            tableView.EndUpdates();
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Items.Count + ((_currentExpandedRowIndex > -1) ? 1 : 0);
        }

        protected bool IsChild(NSIndexPath indexPath)
        {
            return _currentExpandedRowIndex > -1 &&
                   _currentExpandedSectionIndex > -1 &&
                   indexPath.Section == _currentExpandedSectionIndex &&
                   indexPath.Row > _currentExpandedRowIndex &&
                   indexPath.Row <= _currentExpandedRowIndex + _totalExpandedRows;
        }

        void HandleChildSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Debug.WriteLine("Child Row Selected");
            tableView.DeselectRow(indexPath, true);
        }

        void CollapseSubItems(UITableView tableView)
        {
            if (_expandedCellSource?.GetSubList<T>() == null)
                return;

            var currentRowIndex = _currentExpandedRowIndex;
            foreach (T item in _expandedCellSource.GetSubList<T>())
            {
                Items.Remove(item);
                tableView.DeleteRows(new[] { NSIndexPath.FromRowSection(++currentRowIndex, _currentExpandedSectionIndex) }, UITableViewRowAnimation.Fade);
            }


            _currentExpandedSectionIndex = -1;
            _currentExpandedRowIndex = -1;
            _totalExpandedRows = 0;
            _expandedCellSource = null;
        }

        void ExpandItemAtIndex(UITableView tableView,
                               NSIndexPath indexPath,
                               int numberOfExpandedRowsWhenTapped = 0,
                               int expandedRowIndexWhenTapped = 0,
                               int expandedSectionIndexWhenTapped = 0)
        {
            var shouldSubstractNumberOfExpandedRows =
               indexPath.Section == expandedSectionIndexWhenTapped &&
                        indexPath.Row > expandedRowIndexWhenTapped;

            nint selectedItemIndex = 0;
            for (int section = 0; section < indexPath.Section; section++)
            {
                selectedItemIndex += tableView.NumberOfRowsInSection(section);
            }
            selectedItemIndex += indexPath.Row;

            if (shouldSubstractNumberOfExpandedRows)
                selectedItemIndex -= numberOfExpandedRowsWhenTapped;

            _expandedCellSource = Items[(int)selectedItemIndex];
            _currentExpandedSectionIndex = indexPath.Section;
            _currentExpandedRowIndex =
                shouldSubstractNumberOfExpandedRows ?
                indexPath.Row - numberOfExpandedRowsWhenTapped : indexPath.Row;

            if (_expandedCellSource?.GetSubList<T>() == null ||
                _expandedCellSource?.GetSubList<T>().Count <= 0)
                return;

            var currentRowIndex = _currentExpandedRowIndex;
            var currentItemsIndex = (int)selectedItemIndex;
            foreach (T item in _expandedCellSource?.GetSubList<T>() ?? Array.Empty<T>())
            {
                Items.Insert(++currentItemsIndex, item);
                tableView.InsertRows(new[] { NSIndexPath.FromRowSection(++currentRowIndex, indexPath.Section) }, UITableViewRowAnimation.Fade);
                _totalExpandedRows++;
            }
        }
    }
}
