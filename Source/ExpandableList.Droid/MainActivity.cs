using Android.App;
using Android.OS;
using Android.Widget;

namespace ExpandableList.Droid
{
    [Activity(Label = "ExpandableList.Droid", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@android:style/Theme.Material.Light")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var expandableListView = FindViewById<ExpandableListView>(Resource.Id.myExpandableListview);
            expandableListView?.SetAdapter(new ExpandableDataAdapter<LocationModel>(this, LocationModel.CreateLocationList()));

            Title = "Locations Around The World";
        }
    }
}

