using System;
namespace DemoFileLinking.PCL
{
	public class PrinterManeger
	{
		public IPrinter printer
		{
			get;
			set;
		}

		public PrinterManeger(IPrinter printer)
		{
			this.printer = printer;
		}

		public void ShowMessange() 
		{
			printer.ShowMessange();
		}
	}
}
