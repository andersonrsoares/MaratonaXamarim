using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace loginfacebook
{
	public partial class Main : ContentPage
	{
		public Main()
		{
			InitializeComponent();
			this.btnLogar.Clicked +=  (sender, e) =>
			{
				//PushAsync is not supported globally on Android, please use a NavigationPage.
				Navigation.PushAsync(new Login());
			};
		}
	}
}
