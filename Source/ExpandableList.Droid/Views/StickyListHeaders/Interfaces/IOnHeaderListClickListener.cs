using Android.Views;

namespace ExpandableList.Droid
{
    public interface IOnHeaderListClickListener
    {
        void OnHeaderClick(StickyListHeadersListView listView, View header, int itemPosition, long headerId,
                           bool currentlySticky);
    }
}