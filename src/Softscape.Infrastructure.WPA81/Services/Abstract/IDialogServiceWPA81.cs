using System;
using System.Threading.Tasks;

namespace Softscape.Infrastructure.WPA81.Services.Abstract
{
	public interface IDialogServiceWpa81 : PCL.Services.Abstract.IDialogService
	{
		Task<AskQuestionWithTextResponseResult> AskQuestionWithTextResponseAsync(
			string title,
			string value,
			string buttonConfirmText,
			string buttonCancelText = null);

		Task<AskQuestionWithTextResponseResult> AskQuestionWithTextResponseAsync(
			string message,
			string title,
			string value,
			string buttonConfirmText,
			string buttonCancelText);
	}
}
