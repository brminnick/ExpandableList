using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;

namespace ExpandableList.Droid
{
    public class ExpandableDataAdapter<T> : BaseExpandableListAdapter where T : ExpandableListModel
    {
        readonly Activity _context;

        public ExpandableDataAdapter(Activity newContext, IEnumerable<LocationModel> newList)
        {
            _context = newContext;
            LocationList = newList.ToList();
        }

        public override bool HasStableIds => true;
        public override int GroupCount => LocationList.Count;

        protected IReadOnlyList<LocationModel> LocationList { get; }

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition) => throw new NotImplementedException();

        public override long GetChildId(int groupPosition, int childPosition) => childPosition;

        public override Java.Lang.Object GetGroup(int groupPosition) => throw new NotImplementedException();

        public override long GetGroupId(int groupPosition) => groupPosition;

        public override bool IsChildSelectable(int groupPosition, int childPosition) => true;

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override View? GetGroupView(int groupPosition, bool isExpanded, View? convertView, ViewGroup parent)
        {
            var header = convertView switch
            {
                null => _context.LayoutInflater.Inflate(Resource.Layout.ListGroup, null),
                _ => convertView
            };

            if (header?.FindViewById<TextView>(Resource.Id.DataHeader) is TextView textView)
                textView.Text = LocationList[groupPosition].Name;

            return header;
        }

        public override View? GetChildView(int groupPosition, int childPosition, bool isLastChild, View? convertView, ViewGroup parent)
        {
            var row = convertView switch
            {
                null => _context.LayoutInflater.Inflate(Resource.Layout.DataListItem, null),
                _ => convertView
            };

            var sublocations = LocationList[groupPosition].GetSubList<LocationModel>();

            if (row?.FindViewById<TextView>(Resource.Id.DataId) is TextView textView)
                textView.Text = sublocations[childPosition].Name;

            return row;
        }
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).

        public override int GetChildrenCount(int groupPosition) => LocationList[groupPosition].GetSubList<T>().Count;
    }
}

