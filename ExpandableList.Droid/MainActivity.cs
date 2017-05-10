using Android.OS;
using Android.App;
using Android.Widget;

namespace ExpandableList.Droid
{
	[Activity(Label = "ExpandableList.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Main);

			var listView = FindViewById<ExpandableListView>(Resource.Id.myExpandableListview);
			listView.SetAdapter(new ExpandableDataAdapter(this, Data.SampleData()));
		}
	}
}

