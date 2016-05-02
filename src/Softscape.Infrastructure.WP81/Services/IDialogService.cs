using System;
using Coding4Fun.Toolkit.Controls;

namespace Softscape.Infrastructure.WP8.Services
{
	public interface IDialogService
	{
		bool AskYesNoQuestion(string question, string caption = null);

		void ShowMessage(string message, string caption = null);

		void AskQuestionWithTextResponse(string question, string caption, string initialValue, Action<PopUpEventArgs<String, PopUpResult>> action);
	}
}
