using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Softscape.Infrastructure.PCL.Services.Abstract;

namespace Softscape.Infrastructure.PCL.Services
{
	public abstract class NavigationService : INavigationService
	{
		/// <summary>
		/// The frame
		/// </summary>
		private Frame _mainFrame;

		public virtual Task DispatcherGoBackAsync()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets a value indicating whether this instance can go back.
		/// </summary>
		/// <value><c>true</c> if this instance can go back; otherwise, <c>false</c>.</value>
		public bool CanGoBack => CanGoBackImp();

		private bool CanGoBackImp()
		{
			return EnsureMainFrame() && _mainFrame.CanGoBack;
		}

		/// <summary>
		/// Gets the current source.
		/// </summary>
		/// <value>The current source.</value>
		public object CurrentSource
		{
			get
			{
				if (EnsureMainFrame())
				{
					return _mainFrame.Content;
				}

				return null;
			}
		}

		/// <summary>
		/// Goes the back.
		/// </summary>
		public bool GoBack()
		{
			if (!CanGoBackImp()) return false;
			_mainFrame.GoBack();
			return true;
		}

		public virtual Task DispatcherNavigateToAsync(Type type)
		{
			throw new NotImplementedException();
		}

		public virtual Task DispatcherNavigateToAsync(Type type, object parameter)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Navigates to.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns><c>true</c> if navigate to type page; otherwise, <c>false</c>.</returns>
		public bool NavigateTo(Type type)
		{
			if (EnsureMainFrame())
			{
				return _mainFrame.Navigate(type);
			}

			return false;
		}

		public bool NavigateSafelyTo(Type type)
		{
			if (EnsureMainFrame())
			{
				return _mainFrame.Navigate(type);
			}

			return false;
		}

		/// <summary>
		/// Navigates to.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="parameter">The parameter.</param>
		/// <returns>If navigate to</returns>
		public bool NavigateTo(Type type, object parameter)
		{
			if (EnsureMainFrame())
			{
				return _mainFrame.Navigate(type, parameter);
			}

			return false;
		}

		/// <summary>
		/// Ensures the main frame.
		/// </summary>
		/// <returns><c>true</c> if main frame is not null; otherwise, <c>false</c>.</returns>
		private bool EnsureMainFrame()
		{
			_mainFrame = Window.Current.Content as Frame;

			if (_mainFrame != null)
			{
				return true;
			}

			return false;
		}


		public bool RemoveBackStackTop()
		{
			if (EnsureMainFrame() && _mainFrame.CanGoBack)
			{
				_mainFrame.BackStack.RemoveAt(_mainFrame.BackStack.Count - 1);
				return true;
			}
			return false;
		}

		public IList<PageStackEntry> BackStack
		{
			get
			{
				if (EnsureMainFrame())
					return _mainFrame.BackStack;
				else
					return null;
			}
		}


		public Type GetBackStackTopType()
		{
			if (EnsureMainFrame() && _mainFrame.CanGoBack)
			{
				return _mainFrame.BackStack[_mainFrame.BackStack.Count - 1].SourcePageType;
			}
			return null;
		}
	}
}
