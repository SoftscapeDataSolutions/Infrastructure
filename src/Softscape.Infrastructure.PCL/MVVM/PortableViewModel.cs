using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Softscape.Infrastructure.PCL.Services.Abstract;

namespace Softscape.Infrastructure.PCL.MVVM
{
	public class PortableViewModel : ViewModelBase
	{
		public PortableViewModel(IMessenger messenger = null):base(messenger)
		{
			
		}

		#region DialogService
		protected IDialogService GetDialogService()
		{
			return ServiceLocator.Current.GetInstance<IDialogService>();
		}
		#endregion

		#region Navigation
		public INavigationService GetNavigationService()
		{
			return ServiceLocator.Current.GetInstance<INavigationService>();
		}

		public virtual void OnNavigatedTo(NavigationEventArgs e)
		{
		}

		public virtual void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{

		}

		public virtual void OnNavigatedFrom(NavigationEventArgs e)
		{

		}

		public virtual void OnCoreWindowVisibilityChanged(Windows.UI.Core.VisibilityChangedEventArgs args)
		{

		}
		#endregion
	}
}
