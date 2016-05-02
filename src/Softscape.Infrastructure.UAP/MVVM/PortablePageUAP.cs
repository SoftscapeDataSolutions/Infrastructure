using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Softscape.Infrastructure.PCL.MVVM;

namespace Softscape.Infrastructure.UAP.MVVM
{
	public class PortablePageUAP : PortablePage
	{
		private readonly bool _isHardwareButtonsAPIPresent;

		public PortablePageUAP()
		{
			_isHardwareButtonsAPIPresent = Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
		}
		
		protected override void OnFirstLoaded(RoutedEventArgs e)
		{
			base.OnFirstLoaded(e);

			if (_isHardwareButtonsAPIPresent)
			{
				HardwareButtons.BackPressed += HardwareButtons_BackPressed;
			}
		}

		protected override void OnFirstUnloaded(RoutedEventArgs e)
		{
			base.OnFirstLoaded(e);


			HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
		}

		private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
		{
			OnBackKeyPress(e);
		}

		public virtual void OnBackKeyPress(BackPressedEventArgs e)
		{
			var dataContext = DataContext as PortablePageUAPViewModel;
			dataContext?.OnBackKeyPress(e);
		}
	}
}
