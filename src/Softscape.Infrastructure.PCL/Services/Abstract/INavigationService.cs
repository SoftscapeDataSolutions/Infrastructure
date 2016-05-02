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

		Task DispatcherNavigateTo(Type type);
		Task DispatcherNavigateTo(Type type, object parameter);
		Task DispatcherGoBack();

		bool CanGoBack { get; }

		Type GetBackStackTopType();
		bool RemoveBackStackTop();
	}
}
