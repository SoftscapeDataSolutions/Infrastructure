using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.ServiceLocation;
using Softscape.Infrastructure.PCL.Services.Abstract;

namespace Softscape.Infrastructure.PCL.MVVM
{
	public class PortablePage : Page
	{
		#region Attributes
		protected bool IsLoaded;
		#endregion

		#region DialogService
		protected IDialogService GetDialogService()
		{
			return ServiceLocator.Current.GetInstance<IDialogService>();
		}
		#endregion

		#region NavigationService
		public INavigationService GetNavigationService()
		{
			return ServiceLocator.Current.GetInstance<INavigationService>();
		}
		#endregion

		#region Properties
		#endregion

		public PortablePage()
		{
			if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
			{
				Loaded += (sender, e) =>
				{
					if (!IsLoaded)
					{
						IsLoaded = true;

						OnFirstLoaded(e);
						Window.Current.CoreWindow.VisibilityChanged += CoreWindowVisibilityChanged;
					}
				};

				Unloaded += (sender, e) =>
				{
					if (IsLoaded)
					{
						IsLoaded = false;

						OnFirstUnloaded(e);
						Window.Current.CoreWindow.VisibilityChanged -= CoreWindowVisibilityChanged;
					}
				};
			}
		}

		#region Navigation
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var dataContext = DataContext as PortableViewModel;
			dataContext?.OnNavigatedTo(e);
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			var dataContext = DataContext as PortableViewModel;
			dataContext?.OnNavigatedFrom(e);
		}

		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			var dataContext = DataContext as PortableViewModel;
			dataContext?.OnNavigatingFrom(e);

			base.OnNavigatingFrom(e);
		}

		#endregion

		#region Events
		private void CoreWindowVisibilityChanged(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.VisibilityChangedEventArgs e)
		{
			var dataContext = DataContext as PortableViewModel;
			dataContext?.OnCoreWindowVisibilityChanged(e);
		}

		protected virtual void OnFirstLoaded(RoutedEventArgs e)
		{
			
		}

		protected virtual void OnFirstUnloaded(RoutedEventArgs e)
		{

		}
		#endregion
	}
}
