using System;
using System.Globalization;
using Xamarin.Forms;

namespace FormAssistControl
{
	public class AverageToColorConverter:IValueConverter
	{
		public AverageToColorConverter()
		{
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			double avarage = (double)value;
			return avarage < 60 ? Color.Red : Color.Blue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
