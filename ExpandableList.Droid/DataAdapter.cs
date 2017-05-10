using System.Collections.Generic;

using Android.App;
using Android.Views;
using Android.Widget;

namespace ExpandableList.Droid
{
    public class DataAdapter : BaseAdapter<Data>
    {
        #region Constant Fields
        readonly Activity _context;
        #endregion

        #region Constructors
        public DataAdapter(Activity newContext, List<Data> newData)
        {
            _context = newContext;
            DataList = newData;
        }
        #endregion

        #region Properties
        public override int Count => DataList.Count;
        public override Data this[int position] => DataList[position];

        public List<Data> DataList { get; set; }
        #endregion

        #region Methods
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View newView = convertView;

            if (newView == null)
                newView = _context.LayoutInflater.Inflate(Resource.Layout.DataListItem, null);

            newView.FindViewById<TextView>(Resource.Id.DataId).Text = DataList[position].Id;
            newView.FindViewById<TextView>(Resource.Id.DataValue).Text = DataList[position].Value;

            return newView;
        }

        public override long GetItemId(int position) => position;
        #endregion
    }
}

