using System;
using System.Collections;
using System.Windows;
using System.Windows.Data;

namespace Softscape.Infrastructure.WP8Silverlight.XAML
{
	public class BooleanToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value is Visibility && (Visibility)value == Visibility.Visible;
		}
	}

	public class BooleanToVisibilityInversedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return (value is bool && !(bool)value) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value is Visibility && (Visibility)value == Visibility.Collapsed;
		}
	}

	public class BooleanInversedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
				return !(bool)value;
			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
				return !(bool)value;
			return false;
		}
	}

	public class CollectionToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string returnValue;

			if (value == null)
				returnValue = Visibility.Collapsed.ToString();
			else if (((ICollection)value).Count == 0)
				returnValue = Visibility.Collapsed.ToString();
			else
				returnValue = Visibility.Visible.ToString();

			return returnValue;
		}

		// No need to implement converting back on a one-way binding 
		public object ConvertBack(object value, Type targetType,
			object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class CollectionToVisibilityInverseConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string returnValue;

			if (value == null)
				returnValue = Visibility.Visible.ToString();
			else if (((ICollection)value).Count == 0)
				returnValue = Visibility.Visible.ToString();
			else
				returnValue = Visibility.Collapsed.ToString();

			return returnValue;
		}

		// No need to implement converting back on a one-way binding 
		public object ConvertBack(object value, Type targetType,
			object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public sealed class ObjectToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value != null ? Visibility.Visible.ToString() : Visibility.Collapsed.ToString();
		}

		// No need to implement converting back on a one-way binding 
		public object ConvertBack(object value, Type targetType,
			object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public sealed class ObjectToVisibilityInverseConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value != null ? Visibility.Collapsed.ToString() : Visibility.Visible.ToString();
		}

		// No need to implement converting back on a one-way binding 
		public object ConvertBack(object value, Type targetType,
			object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}
	}
}
