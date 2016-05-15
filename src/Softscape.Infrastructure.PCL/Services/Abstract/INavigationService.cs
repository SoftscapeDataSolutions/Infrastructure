using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace Softscape.Infrastructure.PCL.Services.Abstract
{
	public interface INavigationService
	{
		object CurrentSource { get; }

		IList<PageStackEntry> BackStack { get; }

		bool NavigateTo(Type type);
		bool NavigateTo(Type type, object parameter);
		bool GoBack();

		Task DispatcherNavigateToAsync(Type type);
		Task DispatcherNavigateToAsync(Type type, object parameter);
		Task DispatcherGoBackAsync();

		bool CanGoBack { get; }

		Type GetBackStackTopType();
		bool RemoveBackStackTop();
	}
}
