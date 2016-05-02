using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Coding4Fun.Toolkit.Controls;
using GalaSoft.MvvmLight.Threading;

namespace Softscape.Infrastructure.WP8.Services
{
	public class DialogService : IDialogService
	{
		public bool AskYesNoQuestion(string question, string caption = null)
		{
			var messageBoxResult = MessageBox.Show(question, caption, MessageBoxButton.OKCancel);
			return messageBoxResult == MessageBoxResult.OK;
		}

		public void ShowMessage(string message, string caption = null)
		{
			MessageBox.Show(message, caption ?? String.Empty, MessageBoxButton.OK);
		}

		public void AskQuestionWithTextResponse(string question, string caption, string initialValue, Action<PopUpEventArgs<String, PopUpResult>> action)
		{
			DispatcherHelper.CheckBeginInvokeOnUI(
				() =>
				{
					var input = new InputPrompt();
					input.Completed += ((sender, args) => action(args));
					input.Title = caption ?? GetDefaultQuestionCaption();
					input.Message = question;
					input.Value = initialValue;
					input.Show();
				});
		}

		private string GetDefaultQuestionCaption()
		{
			return String.Empty;
		}
	}
}
