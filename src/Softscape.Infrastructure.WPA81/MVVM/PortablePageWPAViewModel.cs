using System;
using System.Linq.Expressions;
using Windows.Phone.UI.Input;
using GalaSoft.MvvmLight.Threading;
using Softscape.Infrastructure.PCL.MVVM;
using Softscape.Infrastructure.WPA81.Common;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace Softscape.Infrastructure.WPA81.MVVM
{
	public class PortablePageWPAViewModel : PortableViewModel
    {
		public PortablePageWPAViewModel(IMessenger messenger = null)
			: base(messenger)
		{
			
		}

        #region PropertyChanged

        public override void RaisePropertyChanged(string propertyName)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => base.RaisePropertyChanged(propertyName));
        }

		public override void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => base.RaisePropertyChanged<T>(propertyExpression));
        }

		public override void RaisePropertyChanged<T>(string propertyName, T oldValue, T newValue, bool broadcast)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(
                () => base.RaisePropertyChanged<T>(propertyName, oldValue, newValue, broadcast));
        }

        
        #endregion

		#region DialogService

		#endregion

		#region NavigationService
		

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
			return GetNavigationService().DispatcherNavigateTo(type);
		}

		public  Task DispatcherNavigateTo(Type type, object parameter)
		{
			return GetNavigationService().DispatcherNavigateTo(type, parameter);
		}

		public Task DispatcherGoBack()
		{
			return GetNavigationService().DispatcherGoBack();
		}
		#endregion

		#region Events
		public virtual void OnBackKeyPress(BackPressedEventArgs e)
		{

		}

		public virtual void NavigationHelperLoadState(object sender, LoadStateEventArgs e)
		{

		}

		public virtual void NavigationHelperSaveState(object sender, SaveStateEventArgs e)
		{

		}
		#endregion
	}
}
