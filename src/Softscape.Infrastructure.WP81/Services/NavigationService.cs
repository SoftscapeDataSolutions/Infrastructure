using System;
using System.Windows;
using System.Windows.Controls;

namespace Softscape.Infrastructure.WP8.Services
{
	public class NavigationService : INavigationService
	{
		private Frame _frameUseProperty;

		private Frame Frame
		{
			get { return _frameUseProperty ?? (_frameUseProperty = (Frame)Application.Current.RootVisual); }
		}

		public Uri Source
		{
			get { return Frame.Source; }
		}

		public void GoBack()
		{
			Frame.GoBack();
		}

		public void Navigate(Uri source)
		{

			try
			{
				Frame.Navigate(source);
			}
			catch (InvalidOperationException)
			{

			}
		}

		public void Navigate(string relativeUrl)
		{
			try
			{
				Frame.Navigate(new Uri(relativeUrl, UriKind.Relative));
			}
			catch (InvalidOperationException)
			{

			}
		}
	}
}
