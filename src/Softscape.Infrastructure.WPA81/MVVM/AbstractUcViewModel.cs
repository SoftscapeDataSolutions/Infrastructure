using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Softscape.Infrastructure.WPA81.MVVM
{
	public class AbstractUcViewModel : ObservableObject
	{
		#region NavigationService
		public PCL.Services.Abstract.INavigationService GetNavigationService()
		{
			return ServiceLocator.Current.GetInstance<PCL.Services.Abstract.INavigationService>();
		}

		public Boolean NavigateTo(Type type)
		{
			return GetNavigationService().NavigateTo(type);
		}

		public Boolean NavigateTo(Type type, object parameter)
		{
			return GetNavigationService().NavigateTo(type, parameter);
		}

		public void GoBack()
		{
			GetNavigationService().GoBack();
		}

		public Task DispatcherNavigateTo(Type type)
		{
			return GetNavigationService().DispatcherNavigateToAsync(type);
		}

		public Task DispatcherNavigateTo(Type type, object parameter)
		{
			return GetNavigationService().DispatcherNavigateToAsync(type, parameter);
		}

		public Task DispatcherGoBack()
		{
			return GetNavigationService().DispatcherGoBackAsync();
		}
		#endregion
	}
}
