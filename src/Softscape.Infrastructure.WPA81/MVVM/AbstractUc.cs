using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Microsoft.Practices.ServiceLocation;
using Softscape.Infrastructure.PCL.Services.Abstract;
using Softscape.Infrastructure.WPA81.Services.Abstract;

namespace Softscape.Infrastructure.WPA81.MVVM
{
	// ReSharper disable once InconsistentNaming
	public class AbstractUc : UserControl
	{
		#region DialogService

		protected IDialogServiceWpa81 GetDialogService()
		{
			return ServiceLocator.Current.GetInstance<IDialogServiceWpa81>();
		}

		#endregion

		#region NavigationService
		public INavigationService GetNavigationService()
		{
			return ServiceLocator.Current.GetInstance<INavigationService>();
		}

		public bool NavigateTo(Type type)
		{
			return GetNavigationService().NavigateTo(type);
		}

		public bool NavigateTo(Type type, object parameter)
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
