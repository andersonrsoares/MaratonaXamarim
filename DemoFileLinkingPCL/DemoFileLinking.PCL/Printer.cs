using System;
namespace DemoFileLinking.Core
{
	public class Printer
	{
		public Printer()
		{
			
		}

		public void ShowMessange() {
			Console.WriteLine("Ola Xamarim");
			#if __ANDROID__
				Console.WriteLine(Android.OS.Build.VERSION.Codename);
			#elif __IOS__ 
				Console.WriteLine(UIKit.UIDevice.CurrentDevice.SystemVersion);
			#endif
		}
	}
}
