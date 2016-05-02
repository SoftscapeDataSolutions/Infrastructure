using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Ioc;
using Softscape.Infrastructure.PCL.Services.Abstract;

namespace Softscape.Infrastructure.W8.MVVM
{
	public class AbstractUc: UserControl
	{
		#region DialogService

		protected IDialogService DialogService
		{
			get { return SimpleIoc.Default.GetInstance<IDialogService>(); }
		}

		#endregion
	}
}
