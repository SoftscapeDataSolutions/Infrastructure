using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Softscape.Infrastructure.PCL.XAML
{
	public class WebViewExtensions
	{
		public static string GetHTML(DependencyObject obj)
		{
			return (string)obj.GetValue(HTMLProperty);
		}

		public static void SetHTML(DependencyObject obj, string value)
		{
			obj.SetValue(HTMLProperty, value);
		}  

		// Using a DependencyProperty as the backing store for HTML.  This enables animation, styling, binding, etc... 
		public static readonly DependencyProperty HTMLProperty =
			DependencyProperty.RegisterAttached(
			"HTML", 
			typeof(string), 
			typeof(WebViewExtensions),
			new PropertyMetadata("", OnHTMLChanged));

		private static void OnHTMLChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{

			var wv = d as WebView;
			if (wv != null)
			{
				wv.NavigateToString((string) e.NewValue);
			}
		}
	}
}
