using System;
using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;

namespace ExpandableList.Droid
{
    public class ExpandableDataAdapter : BaseExpandableListAdapter
    {
        #region Constant Fields
        readonly Activity _context;
        #endregion

        #region Constructors
        public ExpandableDataAdapter(Activity newContext, List<Data> newList)
        {
            _context = newContext;
            DataList = newList;
        }
        #endregion

        #region Properties
        public override bool HasStableIds => true;
		public override int GroupCount => 26;
		protected List<Data> DataList { get; set; }
		#endregion

		#region Methods
		public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            throw new NotImplementedException();
        }

        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            View header = convertView;
            if (header == null)
            {
                header = _context.LayoutInflater.Inflate(Resource.Layout.ListGroup, null);
            }
            header.FindViewById<TextView>(Resource.Id.DataHeader).Text = ((char)(65 + groupPosition)).ToString();

            return header;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = _context.LayoutInflater.Inflate(Resource.Layout.DataListItem, null);
            }
            string newId = "", newValue = "";
            GetChildViewHelper(groupPosition, childPosition, out newId, out newValue);
            row.FindViewById<TextView>(Resource.Id.DataId).Text = newId;
            row.FindViewById<TextView>(Resource.Id.DataValue).Text = newValue;

            return row;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            char letter = (char)(65 + groupPosition);
            List<Data> results = DataList.FindAll((Data obj) => obj.Id[0].Equals(letter));
            return results.Count;
        }

        void GetChildViewHelper(int groupPosition, int childPosition, out string Id, out string Value)
        {
            char letter = (char)(65 + groupPosition);
            List<Data> results = DataList.FindAll((Data obj) => obj.Id[0].Equals(letter));
            Id = results[childPosition].Id;
            Value = results[childPosition].Value;
        }
        #endregion
    }
}

