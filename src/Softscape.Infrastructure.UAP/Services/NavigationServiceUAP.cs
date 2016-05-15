using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Threading;

namespace Softscape.Infrastructure.UAP.Services
{
	public class NavigationServiceUAP: PCL.Services.NavigationService
	{
		public override Task DispatcherNavigateToAsync(Type type)
		{
			return DispatcherHelper.RunAsync(() => { NavigateTo(type); }).AsTask();
		}

		public override Task DispatcherNavigateToAsync(Type type, object parameter)
		{
			return DispatcherHelper.RunAsync(() => { NavigateTo(type, parameter); }).AsTask();
		}

		public override Task DispatcherGoBackAsync()
		{
			return DispatcherHelper.RunAsync(() => { GoBack(); }).AsTask();
		}
	}
}
