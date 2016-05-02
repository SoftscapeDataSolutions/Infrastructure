using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using Softscape.Infrastructure.WP8.Services;

namespace Softscape.Infrastructure.WP8.MVVM
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

        //protected void NotifyPropertyChanged(string propertyName)
        //{
        //    ////http://blog.decarufel.net/2009/03/good-practice-to-use-dispatcher-in-wpf.html
        //    var handler =base.PropertyChanged;
        //    if (handler != null)
        //    {
        //        var dispatcher = Deployment.Current.Dispatcher;

        //        if (dispatcher.CheckAccess())
        //            handler(this, new PropertyChangedEventArgs(propertyName));
        //        else
        //            dispatcher.BeginInvoke(handler, this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        //protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        //{
        //    NotifyPropertyChanged(PropertySupport.ExtractPropertyName(propertyExpression));
        //}

        #endregion

        #region Navigation

        private static INavigationService GetNavigationService()
        {
            return SimpleIoc.Default.GetInstance<INavigationService>();
        }

        protected void Navigate(Uri source)
        {
            GetNavigationService().Navigate(source);
        }

        protected void GoBack()
        {
            GetNavigationService().GoBack();
        }


        #endregion

        #region MessageService

        protected IDialogService DialogService
        {
            get { return SimpleIoc.Default.GetInstance<IDialogService>(); }
        }

        #endregion

		#region Events
		public virtual void OnNavigatedTo()
		{
		}

		public virtual void OnNavigatedFrom()
		{

		}
		#endregion
	}
}
