using System;

namespace Softscape.Infrastructure.WP8.Services
{
	public interface INavigationService
	{
		Uri Source { get; }

		void GoBack();

		void Navigate(Uri source);

		void Navigate(string relativeUrl);
	}
}
