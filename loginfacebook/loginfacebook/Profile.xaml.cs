using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace loginfacebook
{
	public partial class Profile : ContentPage
	{
		string message;

		public Profile()
		{
			InitializeComponent();
		}

		public Profile(string message)
		{
			InitializeComponent();
			this.message = message;
		}
	}
}
