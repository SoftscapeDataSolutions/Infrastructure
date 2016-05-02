using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace Softscape.Infrastructure.WP8.MVVM
{
	public class AbstractPage : PhoneApplicationPage
	{
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var dataContextAsAbstractViewModel = DataContext as AbstractViewModel;
			if (dataContextAsAbstractViewModel != null)
				dataContextAsAbstractViewModel.OnNavigatedTo();

			base.OnNavigatedTo(e);
		}

		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			base.OnNavigatingFrom(e);
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			var dataContextAsAbstractViewModel = DataContext as AbstractViewModel;
			if (dataContextAsAbstractViewModel != null)
				dataContextAsAbstractViewModel.OnNavigatedFrom();

			base.OnNavigatedFrom(e);
		}
	}
}
