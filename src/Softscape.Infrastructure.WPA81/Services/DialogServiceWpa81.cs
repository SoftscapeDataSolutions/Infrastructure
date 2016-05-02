using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Softscape.Infrastructure.WPA81.Services.Abstract;

namespace Softscape.Infrastructure.WPA81.Services
{
	// ReSharper disable once InconsistentNaming
	public class DialogServiceWpa81 : PCL.Services.DialogService, IDialogServiceWpa81
	{
		public async Task<AskQuestionWithTextResponseResult> AskQuestionWithTextResponseAsync(
			String title,
			String value,
			string buttonConfirmText,
			string buttonCancelText)
		{

			return await AskQuestionWithTextResponseAsync(null, title, value, buttonConfirmText, buttonCancelText);
		}


		public async Task<AskQuestionWithTextResponseResult> AskQuestionWithTextResponseAsync(
			string message, 
			string title, 
			string value, 
			string buttonConfirmText, 
			string buttonCancelText)
		{
			var stackPanel = new StackPanel {HorizontalAlignment = HorizontalAlignment.Stretch};

			if (!String.IsNullOrWhiteSpace(message))
			{
				var textBlock = new TextBlock
				                {
					                Text = message, 
									TextWrapping = TextWrapping.Wrap
				                };
				stackPanel.Children.Add(textBlock);
			}
			
			var textBox = new TextBox();
			stackPanel.Children.Add(textBox);

			var dialog = new ContentDialog
			{
				Title = title ?? String.Empty,
				Content = stackPanel
			};

			if (!String.IsNullOrWhiteSpace(value))
				textBox.Text = value;
			textBox.Focus(FocusState.Programmatic);

			dialog.PrimaryButtonText = buttonConfirmText;

			if (!String.IsNullOrWhiteSpace(buttonCancelText))
				dialog.SecondaryButtonText = buttonCancelText;

			var dialogResult = await dialog.ShowAsync();

			var questionResult = new AskQuestionWithTextResponseResult { Result = dialogResult };

			if (dialogResult == ContentDialogResult.Primary)
				questionResult.Value = textBox.Text;

			return questionResult;
		}
	}

	public class AskQuestionWithTextResponseResult
	{
		public ContentDialogResult Result { get; set; }
		public String Value { get; set; }
	}
}
