﻿using System.Diagnostics;
using Xamarin.Forms;

namespace FormAssistControl
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			Debug.WriteLine("App()");
			MainPage = new NavigationPage(new FormAssistControlPage());
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
	}
}
