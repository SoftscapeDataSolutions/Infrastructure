using System;
using System.Linq.Expressions;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using Softscape.Infrastructure.PCL.Services;
using Softscape.Infrastructure.PCL.Services.Abstract;
using Softscape.Infrastructure.W8.Common;

namespace Softscape.Infrastructure.W8.MVVM
{
	public class AbstractViewModel : ViewModelBase
	{
		#region PropertyChanged

		protected override void RaisePropertyChanged(string propertyName)
		{
			DispatcherHelper.CheckBeginInvokeOnUI(() => base.RaisePropertyChanged(propertyName));
		}

		protected override void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
		{
			DispatcherHelper.CheckBeginInvokeOnUI(() => base.RaisePropertyChanged<T>(propertyExpression));
		}

		protected override void RaisePropertyChanged<T>(string propertyName, T oldValue, T newValue, bool broadcast)
		{
			DispatcherHelper.CheckBeginInvokeOnUI(
				() => base.RaisePropertyChanged<T>(propertyName, oldValue, newValue, broadcast));
		}

		#endregion

		#region NavigationService
		public INavigationService GetNavigationService()
		{
			return SimpleIoc.Default.GetInstance<INavigationService>();
		}

		public void NavigateTo(Type type)
		{
			GetNavigationService().NavigateTo(type);
		}

		public void NavigateTo(Type type, object parameter)
		{
			GetNavigationService().NavigateTo(type, parameter);
		}

		public void GoBack()
		{
			GetNavigationService().GoBack();
		}
		#endregion

		#region DialogService

		public IDialogService GetDialogService()
		{
			return SimpleIoc.Default.GetInstance<IDialogService>();
		}

		#endregion

		#region Events
		public virtual void OnNavigatedTo(NavigationEventArgs e)
		{
		}

		public virtual void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{

		}

		public virtual void OnNavigatedFrom(NavigationEventArgs e)
		{

		}

		public virtual void NavigationHelperLoadState(object sender, LoadStateEventArgs e)
		{

		}

		public virtual void NavigationHelperSaveState(object sender, SaveStateEventArgs e)
		{

		}

		public virtual void OnCoreWindowVisibilityChanged(Windows.UI.Core.VisibilityChangedEventArgs args)
		{

		}
		#endregion
	}
}
