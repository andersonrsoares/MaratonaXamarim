using System;

using Xamarin.Forms;

namespace loginfacebook
{
	public class Main : ContentPage
	{
		public Main()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

