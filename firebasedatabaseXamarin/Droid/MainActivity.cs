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

namespace firebasedatabaseXamarin.Droid
{
	[Activity(Label = "firebasedatabaseXamarin.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());

			FirebaseApp app = FirebaseApp.GetInstance(FirebaseApp.DefaultAppName);
			firebaseDatabaseReference = FirebaseDatabase.GetInstance(app).GetReference("https://testefirebase-6bded.firebaseio.com/");
			Query query = firebaseDatabaseReference.Child("users")
			.OrderByChild("name")
					.StartAt("anderson").EndAt("anderson");


			query.AddValueEventListener(new MyValueListener()); 

		}
		DatabaseReference firebaseDatabaseReference;
	
	}

	public class MyValueListener : IValueEventListener
	{
		public IntPtr Handle
		{
			get
			{
				return Handle;
			}
		}

		public void Dispose()
		{
	
		}

		public void OnCancelled(DatabaseError error)
		{
			Log.d("mFirebase", "OnCancelled: " + error.ToString());
		}

		public void OnDataChange(DataSnapshot snapshot)
		{
	
			Log.d("mFirebase", "onDataChange: " + snapshot.ToString());
		}
	}
}
