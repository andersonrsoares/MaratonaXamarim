﻿using System;
using DemoFileLinking.PCL;

namespace DemoFileLinking
{
	public class Printer:IPrinter
	{
		public Printer()
		{
			
		}

		public void ShowMessange()
		{
			Console.WriteLine("Ola Xamarim");
			Console.WriteLine(Android.OS.Build.VERSION.Sdk);
		}
	}
}
