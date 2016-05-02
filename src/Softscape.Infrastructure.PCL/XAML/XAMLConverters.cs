using System;
using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Softscape.Infrastructure.PCL.XAML
{
	public class BooleanToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value is Visibility && (Visibility)value == Visibility.Visible;
		}
	}

	public class BooleanToVisibilityInversedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return (value is bool && !(bool)value) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value is Visibility && (Visibility)value == Visibility.Collapsed;
		}
	}

	public class BooleanInversedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is bool)
				return !(bool)value;
			return false;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			if (value is bool)
				return !(bool)value;
			return false;
		}
	}

	public class CollectionToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
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

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public class CollectionToVisibilityInversedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			String returnValue;

			if (value == null)
				returnValue = Visibility.Visible.ToString();
			else if (((ICollection)value).Count == 0)
				returnValue = Visibility.Visible.ToString();
			else
				returnValue = Visibility.Collapsed.ToString();

			return returnValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public class CollectionToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			Boolean returnValue;

			if (value == null)
				returnValue = false;
			else if (((ICollection)value).Count == 0)
				returnValue = false;
			else
				returnValue = true;

			return returnValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public class CollectionToBooleanInversedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			Boolean returnValue;

			if (value == null)
				returnValue = true;
			else if (((ICollection)value).Count == 0)
				returnValue = true;
			else
				returnValue = false;

			return returnValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public class CountToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			string returnValue;

			if (value == null)
				returnValue = Visibility.Collapsed.ToString();
			else if ((Int32)value == 0)
				returnValue = Visibility.Collapsed.ToString();
			else
				returnValue = Visibility.Visible.ToString();

			return returnValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public class StringFormatConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
				return null;

			// No format provided.
			if (parameter == null)
				return value;
			

			return String.Format((String)parameter, value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value;
		}
	}

	public class StringTrimConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (!(value is String))
				return null;

			return ((String)value).Trim();
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value;
		}
	}

	public class DateFormatConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
				return null;

			var format = "dd MMM yyyy - HH:mm";
			if (parameter != null)
				format = (String)parameter;

			return ((DateTime)value).ToString(format);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public class Int64FormatConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
				return null;

			var format = "D";
			if (parameter != null)
				format = (String)parameter;

			return ((Int64)value).ToString(format);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public sealed class ObjectToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return value != null ? Visibility.Visible.ToString() : Visibility.Collapsed.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public sealed class ObjectToVisibilityInversedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return value != null ? Visibility.Collapsed.ToString() : Visibility.Visible.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public sealed class ObjectToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return value != null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public sealed class ObjectToBooleanInversedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return value != null ? false : true;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public sealed class IntToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value != null && ((Int32)value > 0))
				return Visibility.Visible;
			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public sealed class IntToVisibilityInversedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value != null && ((Int32)value > 0))
				return Visibility.Collapsed;
			return Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}

	public class AndroidStringFormatConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			// No format provided.
			if (parameter == null || parameter as String == null)
			{
				return value;
			}

			var convertedParameter = (String)parameter;
			convertedParameter = convertedParameter.Replace("%d", "{0}");
			return String.Format(convertedParameter, value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value;
		}
	}
}
