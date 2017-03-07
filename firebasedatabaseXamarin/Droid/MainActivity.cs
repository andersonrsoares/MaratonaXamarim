using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase.Database;
using Firebase;
using Android.Util;

namespace firebasedatabaseXamarin.Droid
{
	[Activity(Label = "firebasedatabaseXamarin.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IValueEventListener
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());

			FirebaseApp app = FirebaseApp.GetInstance(FirebaseApp.DefaultAppName);
			firebaseDatabaseReference = FirebaseDatabase.GetInstance(app).GetReferenceFromUrl("https://testefirebase-6bded.firebaseio.com");//
			Query query = firebaseDatabaseReference.Child("users")
			.OrderByChild("name")
					.StartAt("anderson").EndAt("anderson");


			query.AddValueEventListener(this); 

		}

		DatabaseReference firebaseDatabaseReference;
		public void OnCancelled(DatabaseError error)
		{
			Log.Debug("mFirebase", "OnCancelled: " + error.ToString());
		}

		public void OnDataChange(DataSnapshot snapshot)
		{

			Log.Debug("mFirebase", "onDataChange: " + snapshot.ToString());
		}
	
	}




}
