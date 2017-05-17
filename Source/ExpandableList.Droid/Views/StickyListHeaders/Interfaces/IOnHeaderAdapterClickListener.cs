using Android.Views;

namespace ExpandableList.Droid
{
    public interface IOnHeaderAdapterClickListener
    {
        void OnHeaderClick(View header, int itemPosition, long headerId);
    }
}