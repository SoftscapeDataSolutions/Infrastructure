using System;
using System.Threading.Tasks;

namespace Softscape.Infrastructure.PCL.Services.Abstract
{
	public interface IDialogService
	{
		Task ShowMessageAsync(
			string message);

		Task ShowMessageAsync(
			string message,
			string title);

		Task ShowMessageAsync(
			string message,
			string title,
			string buttonText);

		Task<Boolean> ShowMessageAsync(
			string message,
			string title,
			string buttonConfirmText,
			string buttonCancelText);

		#if WINDOWS_PHONE_APP

		#endif
	}
}
