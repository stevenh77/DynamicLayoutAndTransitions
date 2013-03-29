using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DynamicLayoutAndTransitions
{
	public sealed class SecondsToDurationConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
		{
			return new Duration(TimeSpan.FromSeconds((double)value));
		}

		public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
		{
			throw new System.NotImplementedException();
		}
		#endregion
	}

}