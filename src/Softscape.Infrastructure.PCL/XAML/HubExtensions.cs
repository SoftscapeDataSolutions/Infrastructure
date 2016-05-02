using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Softscape.Infrastructure.PCL.XAML
{
	public static class HubExtensions
	{
		/// <summary>
		///  ScrollViewer childScrollViewer = findChildScrollViewer(yourHub);
        ///    if (childScrollViewer != null)
        ///    {
        ///        double horizOffset = (double)childScrollViewer.GetValue(ScrollViewer.HorizontalOffsetProperty);
        ///        double vertOffset = (double)childScrollViewer.GetValue(ScrollViewer.VerticalOffsetProperty);
		///    }
		/// </summary>
		/// <param name="hub"></param>
		/// <returns></returns>
		public static ScrollViewer FindChildScrollViewer(this Hub hub)
		{
			var children = new Queue<DependencyObject>();
			children.Enqueue(hub);
			while (children.Count != 0)
			{
				var dequeued = children.Dequeue();
				if (dequeued is ScrollViewer)
				{
					return (ScrollViewer)dequeued;
				}
				else
				{
					for (var index = 0; index < VisualTreeHelper.GetChildrenCount(dequeued); index++)
					{
						children.Enqueue(VisualTreeHelper.GetChild(dequeued, index));
					}
				}
			}
			return null;
		}
	}
}
