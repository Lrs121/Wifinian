﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WlanProfileViewer.Views.Converters
{
	[ValueConversion(typeof(Visibility), typeof(Visibility))]
	public class VisibilityInverseConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is Visibility sourceValue))
				return DependencyProperty.UnsetValue;

			return (sourceValue == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Convert(value, targetType, parameter, culture);
		}
	}
}