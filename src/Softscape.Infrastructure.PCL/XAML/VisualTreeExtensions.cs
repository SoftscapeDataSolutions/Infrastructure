using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Softscape.Infrastructure.PCL.XAML
{
	public static class VisualTreeExtensions
	{
		public static IEnumerable<DependencyObject> GetVisualAncestors(this DependencyObject element)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			return GetVisualAncestorsAndSelfIterator(element).Skip(1);
		}

		public static IEnumerable<DependencyObject> GetVisualAncestorsAndSelf(this DependencyObject element)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			return GetVisualAncestorsAndSelfIterator(element);
		}

		private static IEnumerable<DependencyObject> GetVisualAncestorsAndSelfIterator(DependencyObject element)
		{
			for (var obj = element; obj != null; obj = VisualTreeHelper.GetParent(obj))
				yield return obj;
		}

		public static IEnumerable<T> GetVisualChildren<T>(this DependencyObject target) where T : DependencyObject
		{
			return GetVisualChildren(target).Where(child => child is T).Cast<T>();
		}

		public static IEnumerable<T> GetVisualChildren<T>(this DependencyObject target, bool strict)
			where T : DependencyObject
		{
			return
				Enumerable.Cast<T>(
					(IEnumerable)
						Enumerable.Where<DependencyObject>(VisualTreeExtensions.GetVisualChildren(target, strict),
							(Func<DependencyObject, bool>)(child => child is T)));
		}

		public static IEnumerable<DependencyObject> GetVisualChildren(this DependencyObject target, bool strict)
		{
			int count = VisualTreeHelper.GetChildrenCount(target);
			if (count == 0)
			{
				if (!strict && target is ContentControl)
				{
					DependencyObject child = ((ContentControl)target).Content as DependencyObject;
					if (child != null)
						yield return child;
				}
			}
			else
			{
				for (int i = 0; i < count; ++i)
					yield return VisualTreeHelper.GetChild(target, i);
			}
		}

		public static IEnumerable<DependencyObject> GetVisualChildren(this DependencyObject element)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			else
				return Enumerable.Skip<DependencyObject>(VisualTreeExtensions.GetVisualChildrenAndSelfIterator(element), 1);
		}

		public static IEnumerable<DependencyObject> GetVisualChildrenAndSelf(this DependencyObject element)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			else
				return VisualTreeExtensions.GetVisualChildrenAndSelfIterator(element);
		}

		private static IEnumerable<DependencyObject> GetVisualChildrenAndSelfIterator(this DependencyObject element)
		{
			yield return element;
			int count = VisualTreeHelper.GetChildrenCount(element);
			for (int i = 0; i < count; ++i)
				yield return VisualTreeHelper.GetChild(element, i);
		}

		private static IEnumerable<DependencyObject> GetVisualDecendants(DependencyObject target, bool strict,
			Queue<DependencyObject> queue)
		{
			foreach (DependencyObject dependencyObject in VisualTreeExtensions.GetVisualChildren(target, strict))
				queue.Enqueue(dependencyObject);
			if (queue.Count != 0)
			{
				DependencyObject node = queue.Dequeue();
				yield return node;
				foreach (DependencyObject dependencyObject in VisualTreeExtensions.GetVisualDecendants(node, strict, queue))
					yield return dependencyObject;
			}
		}

		private static IEnumerable<DependencyObject> GetVisualDecendants(DependencyObject target, bool strict,
			Stack<DependencyObject> stack)
		{
			foreach (DependencyObject dependencyObject in VisualTreeExtensions.GetVisualChildren(target, strict))
				stack.Push(dependencyObject);
			if (stack.Count != 0)
			{
				DependencyObject node = stack.Pop();
				yield return node;
				foreach (DependencyObject dependencyObject in VisualTreeExtensions.GetVisualDecendants(node, strict, stack))
					yield return dependencyObject;
			}
		}

		public static IEnumerable<DependencyObject> GetVisualDescendants(this DependencyObject element)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			else
				return Enumerable.Skip<DependencyObject>(VisualTreeExtensions.GetVisualDescendantsAndSelfIterator(element), 1);
		}

		public static IEnumerable<DependencyObject> GetVisualDescendantsAndSelf(this DependencyObject element)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			else
				return VisualTreeExtensions.GetVisualDescendantsAndSelfIterator(element);
		}

		private static IEnumerable<DependencyObject> GetVisualDescendantsAndSelfIterator(DependencyObject element)
		{
			Queue<DependencyObject> remaining = new Queue<DependencyObject>();
			remaining.Enqueue(element);
			while (remaining.Count > 0)
			{
				DependencyObject obj = remaining.Dequeue();
				yield return obj;
				foreach (DependencyObject dependencyObject in VisualTreeExtensions.GetVisualChildren(obj))
					remaining.Enqueue(dependencyObject);
			}
		}

		public static IEnumerable<DependencyObject> GetVisualSiblings(this DependencyObject element)
		{
			return Enumerable.Where<DependencyObject>(VisualTreeExtensions.GetVisualSiblingsAndSelf(element),
				(Func<DependencyObject, bool>)(p => p != element));
		}

		public static IEnumerable<DependencyObject> GetVisualSiblingsAndSelf(this DependencyObject element)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			DependencyObject parent = VisualTreeHelper.GetParent(element);
			if (parent != null)
				return VisualTreeExtensions.GetVisualChildren(parent);
			else
				return Enumerable.Empty<DependencyObject>();
		}

		public static Rect? GetBoundsRelativeTo(this FrameworkElement element, UIElement otherElement)
		{
			if (element == null)
				throw new ArgumentNullException("element");
			if (otherElement == null)
				throw new ArgumentNullException("otherElement");
			try
			{
				GeneralTransform generalTransform = element.TransformToVisual(otherElement);
				if (generalTransform != null)
				{
					Point outPoint1;
					if (generalTransform.TryTransform(new Point(), out outPoint1))
					{
						Point outPoint2;
						if (generalTransform.TryTransform(new Point(element.ActualWidth, element.ActualHeight), out outPoint2))
							return new Rect?(new Rect(outPoint1, outPoint2));
					}
				}
			}
			catch (ArgumentException)
			{
			}
			return new Rect?();
		}

		public static childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
		{
			for (int childIndex = 0; childIndex < VisualTreeHelper.GetChildrenCount(obj); ++childIndex)
			{
				DependencyObject child = VisualTreeHelper.GetChild(obj, childIndex);
				if (child != null && child is childItem)
					return (childItem)child;
				childItem visualChild = VisualTreeExtensions.FindVisualChild<childItem>(child);
				if ((object)visualChild != null)
					return visualChild;
			}
			return default(childItem);
		}

		public static FrameworkElement FindVisualChild(this FrameworkElement root, string name)
		{
			FrameworkElement frameworkElement1 = root.FindName(name) as FrameworkElement;
			if (frameworkElement1 != null)
				return frameworkElement1;
			foreach (FrameworkElement frameworkElement2 in VisualTreeExtensions.GetVisualChildren((DependencyObject)root))
			{
				FrameworkElement frameworkElement3 = frameworkElement2.FindName(name) as FrameworkElement;
				if (frameworkElement3 != null)
					return frameworkElement3;
			}
			return (FrameworkElement)null;
		}

		public static IEnumerable<DependencyObject> GetVisuals(this DependencyObject root)
		{
			int count = VisualTreeHelper.GetChildrenCount(root);
			for (int i = 0; i < count; ++i)
			{
				DependencyObject child = VisualTreeHelper.GetChild(root, i);
				yield return child;
				foreach (DependencyObject dependencyObject in VisualTreeExtensions.GetVisuals(child))
					yield return dependencyObject;
			}
		}

		public static FrameworkElement GetVisualChild(this FrameworkElement node, int index)
		{
			return VisualTreeHelper.GetChild((DependencyObject)node, index) as FrameworkElement;
		}

		public static FrameworkElement GetVisualParent(this FrameworkElement node)
		{
			return VisualTreeHelper.GetParent((DependencyObject)node) as FrameworkElement;
		}

		public static VisualStateGroup GetVisualStateGroup(this FrameworkElement root, string groupName, bool searchAncestors)
		{
			foreach (object obj in (IEnumerable)VisualStateManager.GetVisualStateGroups(root))
			{
				VisualStateGroup visualStateGroup = obj as VisualStateGroup;
				if (visualStateGroup != null && visualStateGroup.Name == groupName)
					return visualStateGroup;
			}
			if (searchAncestors)
			{
				FrameworkElement visualParent = VisualTreeExtensions.GetVisualParent(root);
				if (visualParent != null)
					return VisualTreeExtensions.GetVisualStateGroup(visualParent, groupName, true);
			}
			return (VisualStateGroup)null;
		}

		[Conditional("DEBUG")]
		public static void GetVisualChildTreeDebugText(this FrameworkElement root, StringBuilder result)
		{
			List<string> results = new List<string>();
			VisualTreeExtensions.GetChildTree(root, "", "  ", results);
			foreach (string str in results)
				result.AppendLine(str);
		}

		private static void GetChildTree(this FrameworkElement root, string prefix, string addPrefix, List<string> results)
		{
			string str = (!string.IsNullOrEmpty(root.Name) ? "[" + root.Name + "]" : "[Anonymous]") + " : " + root.GetType().Name;
			results.Add(prefix + str);
			foreach (FrameworkElement root1 in VisualTreeExtensions.GetVisualChildren((DependencyObject)root))
				VisualTreeExtensions.GetChildTree(root1, prefix + addPrefix, addPrefix, results);
		}

		[Conditional("DEBUG")]
		public static void GetAncestorVisualTreeDebugText(this FrameworkElement node, StringBuilder result)
		{
			List<string> children = new List<string>();
			VisualTreeExtensions.GetAncestorVisualTree(node, children);
			string str1 = "";
			foreach (string str2 in children)
			{
				result.AppendLine(str1 + str2);
				str1 = str1 + "  ";
			}
		}

		private static void GetAncestorVisualTree(this FrameworkElement node, List<string> children)
		{
			string str = (string.IsNullOrEmpty(node.Name) ? "[Anon]" : node.Name) + ": " + node.GetType().Name;
			children.Insert(0, str);
			FrameworkElement visualParent = VisualTreeExtensions.GetVisualParent(node);
			if (visualParent == null)
				return;
			VisualTreeExtensions.GetAncestorVisualTree(visualParent, children);
		}


		public static string GetTransformPropertyPath<RequestedType>(this FrameworkElement element, string subProperty)
			where RequestedType : Transform
		{
			Transform renderTransform = element.RenderTransform;
			if (renderTransform is RequestedType)
				return string.Format("(RenderTransform).({0}.{1})", (object)typeof(RequestedType).Name, (object)subProperty);
			if (renderTransform is TransformGroup)
			{
				TransformGroup transformGroup = renderTransform as TransformGroup;
				for (int index = 0; index < transformGroup.Children.Count; ++index)
				{
					if (transformGroup.Children[index] is RequestedType)
						return string.Format("(RenderTransform).(TransformGroup.Children)[" + (object)index + "].({0}.{1})",
							(object)typeof(RequestedType).Name, (object)subProperty);
				}
			}
			return "";
		}

		public static PlaneProjection GetPlaneProjection(this UIElement element, bool create)
		{
			Projection projection = element.Projection;
			PlaneProjection planeProjection = (PlaneProjection)null;
			if (projection is PlaneProjection)
				return projection as PlaneProjection;
			if (projection == null && create)
			{
				planeProjection = new PlaneProjection();
				element.Projection = (Projection)planeProjection;
			}
			return planeProjection;
		}



		internal static IEnumerable<FrameworkElement> GetLogicalDescendents(this FrameworkElement parent)
		{
			return (IEnumerable<FrameworkElement>)null;
		}
	}
}
