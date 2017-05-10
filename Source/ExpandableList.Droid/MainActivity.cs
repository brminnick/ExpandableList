using Android.OS;
using Android.App;
using Android.Widget;

using ExpandableList.Shared;

namespace ExpandableList.Droid
{
    [Activity(Label = "ExpandableList.Droid", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@android:style/Theme.Material.Light")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Main);

            var expandableListView = FindViewById<ExpandableListView>(Resource.Id.myExpandableListview);
			expandableListView.SetAdapter(new ExpandableDataAdapter<ChoreModel>(this, ChoreModel.CreateChoreList()));

            Title = "Chore List";
		}
	}
}

