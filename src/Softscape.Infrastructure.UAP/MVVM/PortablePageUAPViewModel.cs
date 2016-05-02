using System;
using System.Linq.Expressions;
using Windows.Phone.UI.Input;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using Softscape.Infrastructure.PCL.MVVM;

namespace Softscape.Infrastructure.UAP.MVVM
{
	public class PortablePageUAPViewModel : PortableViewModel
    {
		public PortablePageUAPViewModel(IMessenger messenger = null)
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
		#endregion

		#region Events
		public virtual void OnBackKeyPress(BackPressedEventArgs e)
		{

		}
		#endregion
	}
}
