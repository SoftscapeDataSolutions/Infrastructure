using System;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml.Navigation;
using Softscape.Infrastructure.WPA81.Common;
using System.Threading.Tasks;
using Softscape.Infrastructure.PCL.MVVM;

namespace Softscape.Infrastructure.WPA81.MVVM
{
	public class PortablePageWPA : PortablePage
	{
		#region Attributes
		private readonly NavigationHelper _navigationHelper;
		#endregion

		#region DialogService
		#endregion

		#region NavigationService
		protected void NavigateTo(Type type)
		{
			GetNavigationService().NavigateTo(type);
		}

		protected void NavigateTo(Type type, object parameter)
		{
			GetNavigationService().NavigateTo(type, parameter);
		}

		protected void GoBack()
		{
			GetNavigationService().GoBack();
		}

		public Task DispatcherNavigateTo(Type type)
		{
			return GetNavigationService().DispatcherNavigateTo(type);
		}

		public Task DispatcherNavigateTo(Type type, object parameter)
		{
			return GetNavigationService().DispatcherNavigateTo(type, parameter);
		}

		public Task DispatcherGoBack()
		{
			return GetNavigationService().DispatcherGoBack();
		}
		#endregion

		#region Properties
		/// <summary>
		/// NavigationHelper is used on each page to aid in navigation and 
		/// process lifetime management
		/// </summary>
		public NavigationHelper NavigationHelper => _navigationHelper;

		#endregion

		public PortablePageWPA()
		{
			if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
			{
				_navigationHelper = new NavigationHelper(this);
				_navigationHelper.LoadState += NavigationHelperLoadState;
				_navigationHelper.SaveState += NavigationHelperSaveState;
			}
		}

		#region Navigation
		/// <summary>
		/// Populates the page with content passed during navigation. Any saved state is also
		/// provided when recreating a page from a prior session.
		/// </summary>
		/// <param name="sender">
		/// The source of the event; typically <see cref="NavigationHelper"/>
		/// </param>
		/// <param name="e">Event data that provides both the navigation parameter passed to
		/// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
		/// a dictionary of state preserved by this page during an earlier
		/// session. The state will be null the first time a page is visited.</param>
		protected virtual void NavigationHelperLoadState(object sender, LoadStateEventArgs e)
		{
			var dataContext = DataContext as PortablePageWPAViewModel;
			dataContext?.NavigationHelperLoadState(sender, e);
		}

		/// <summary>
		/// Preserves state associated with this page in case the application is suspended or the
		/// page is discarded from the navigation cache.  Values must conform to the serialization
		/// requirements of <see cref="SuspensionManager.SessionState"/>.
		/// </summary>
		/// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
		/// <param name="e">Event data that provides an empty dictionary to be populated with
		/// serializable state.</param>
		protected virtual void NavigationHelperSaveState(object sender, SaveStateEventArgs e)
		{
			var dataContext = DataContext as PortablePageWPAViewModel;
			dataContext?.NavigationHelperSaveState(sender, e);
		}

		#region NavigationHelper registration

		/// The methods provided in this section are simply used to allow
		/// NavigationHelper to respond to the page's navigation methods.
		/// 
		/// Page specific logic should be placed in event handlers for the  
		/// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
		/// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
		/// The navigation parameter is available in the LoadState method 
		/// in addition to page state preserved during an earlier session.

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var dataContext = DataContext as PortablePageWPAViewModel;
			if (dataContext != null)
				dataContext.OnNavigatedTo(e);

			_navigationHelper.OnNavigatedTo(e);
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			var dataContext = DataContext as PortablePageWPAViewModel;
			if (dataContext != null)
				dataContext.OnNavigatedFrom(e);

            _navigationHelper.OnNavigatedFrom(e);
		}

		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			var dataContext = DataContext as PortablePageWPAViewModel;
			if (dataContext != null)
				dataContext.OnNavigatingFrom(e);

			base.OnNavigatingFrom(e);
		}

		#endregion
		#endregion

		#region Events
		public virtual void OnBackKeyPress(BackPressedEventArgs e)
		{
			var dataContext = DataContext as PortablePageWPAViewModel;
			dataContext?.OnBackKeyPress(e);
		}
		#endregion
	}
}
