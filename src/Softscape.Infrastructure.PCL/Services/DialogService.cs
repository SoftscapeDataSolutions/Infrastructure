using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Softscape.Infrastructure.PCL.Services.Abstract;

namespace Softscape.Infrastructure.PCL.Services
{
	public class DialogService : IDialogService
	{
		public async Task ShowMessageAsync(string message)
		{
			await ShowMessageAsync(message, string.Empty);
		}

		public async Task ShowMessageAsync(string message, string title)
		{
			var dialog = new MessageDialog(message, title ?? string.Empty);
			await dialog.ShowAsync();
		}

		public async Task ShowMessageAsync(string message, string title, string buttonText)
		{
			var dialog = new MessageDialog(message, title ?? string.Empty);
			dialog.Commands.Add(new UICommand(buttonText));
			dialog.CancelCommandIndex = 0;
			await dialog.ShowAsync();
		}

		public async Task<bool> ShowMessageAsync(
			string message,
			string title,
			string buttonConfirmText,
			string buttonCancelText)
		{
			var dialog = new MessageDialog(message, title ?? string.Empty);
			dialog.Commands.Add(new UICommand(buttonConfirmText, c => { },1));
			dialog.Commands.Add(new UICommand(buttonCancelText, c => { },2));
			dialog.CancelCommandIndex = 1;
			var result = await dialog.ShowAsync();

			return (int?) result?.Id == 1;
		}
	}
}
