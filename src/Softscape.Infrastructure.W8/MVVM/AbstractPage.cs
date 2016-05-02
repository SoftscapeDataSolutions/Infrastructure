using System;
using Windows.ApplicationModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Ioc;
using Softscape.Infrastructure.PCL.Services.Abstract;
using Softscape.Infrastructure.W8.Common;

namespace Softscape.Infrastructure.W8.MVVM
{
	public class AbstractPage : Page
	{
		#region Attributes
		private bool _isLoaded;
		#endregion

		#region Properties
		public NavigationHelper NavigationHelper { get; private set; }
		#endregion

		#region DialogService

		public IDialogService GetDialogService()
		{
			return SimpleIoc.Default.GetInstance<IDialogService>();
		}

		#endregion

		#region NavigationService
		public INavigationService NavigationService
		{
			get { return SimpleIoc.Default.GetInstance<INavigationService>(); }
		}

		public void NavigateTo(Type type)
		{
			NavigationService.NavigateTo(type);
		}

		public void NavigateTo(Type type, object parameter)
		{
			NavigationService.NavigateTo(type, parameter);
		}

		public void GoBack()
		{
			NavigationService.GoBack();
		}
		#endregion

		public AbstractPage()
		{
			if (!DesignMode.DesignModeEnabled)
			{
				NavigationHelper = new NavigationHelper(this);
				NavigationHelper.LoadState += NavigationHelperLoadState;
				NavigationHelper.SaveState += NavigationHelperSaveState;

				Loaded += (sender, e) =>
				{
					if (!_isLoaded)
					{
						_isLoaded = true;

						Window.Current.CoreWindow.VisibilityChanged += CoreWindowVisibilityChanged;
					}
				};

				Unloaded += (sender, e) =>
				{
					if (_isLoaded)
					{
						_isLoaded = false;

						Window.Current.CoreWindow.VisibilityChanged -= CoreWindowVisibilityChanged;
					}
				};
			}
		}

		#region Navigation
		/// <summary>
		/// Populates the page with content passed during navigation. Any saved state is also
		/// provided when recreating a page from a prior session.
		/// </summary>
		/// <param name="sender">
		/// The source of the event; typically <see cref="Common.NavigationHelper"/>
		/// </param>
		/// <param name="e">Event data that provides both the navigation parameter passed to
		/// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
		/// a dictionary of state preserved by this page during an earlier
		/// session. The state will be null the first time a page is visited.</param>
		protected virtual void NavigationHelperLoadState(object sender, LoadStateEventArgs e)
		{
			var zfViewModel = DataContext as AbstractViewModel;

			if (zfViewModel != null)
				zfViewModel.NavigationHelperLoadState(sender, e);
		}

		/// <summary>
		/// Preserves state associated with this page in case the application is suspended or the
		/// page is discarded from the navigation cache.  Values must conform to the serialization
		/// requirements of <see cref="SuspensionManager.SessionState"/>.
		/// </summary>
		/// <param name="sender">The source of the event; typically <see cref="Common.NavigationHelper"/></param>
		/// <param name="e">Event data that provides an empty dictionary to be populated with
		/// serializable state.</param>
		protected virtual void NavigationHelperSaveState(object sender, SaveStateEventArgs e)
		{
			var zfViewModel = DataContext as AbstractViewModel;

			if (zfViewModel != null)
				zfViewModel.NavigationHelperSaveState(sender, e);
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
			var dataContext = DataContext as AbstractViewModel;
			if (dataContext != null)
				dataContext.OnNavigatedTo(e);

			NavigationHelper.OnNavigatedTo(e);
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			var dataContext = DataContext as AbstractViewModel;
			if (dataContext != null)
				dataContext.OnNavigatedFrom(e);

			NavigationHelper.OnNavigatedFrom(e);
		}

		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			var dataContext = DataContext as AbstractViewModel;
			if (dataContext != null)
				dataContext.OnNavigatingFrom(e);

			base.OnNavigatingFrom(e);
		}

		#endregion
		#endregion

		#region Events
		void CoreWindowVisibilityChanged(CoreWindow sender, VisibilityChangedEventArgs e)
		{
			var dataContext = DataContext as AbstractViewModel;
			if (dataContext != null)
				dataContext.OnCoreWindowVisibilityChanged(e);
		}
		#endregion
	}
}
