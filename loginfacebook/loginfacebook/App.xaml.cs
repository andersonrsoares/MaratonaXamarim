using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace loginfacebook
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new Main());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}


		public static Action HideLoginView
		{
			get
			{
				return new Action(() => App.Current.MainPage.Navigation.PopModalAsync());
			}
		}

		public async static Task NavigateToProfile(string message)
		{
			await App.Current.MainPage.Navigation.PushAsync(new Profile(message));
		}

	}
}
