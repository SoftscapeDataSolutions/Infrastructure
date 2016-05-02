using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Softscape.Infrastructure.PCL.Services.Abstract;

namespace Softscape.Infrastructure.PCL.Services
{
	public class StorageSettingsService : IStorageSettingsService
	{
		#region Attributes
		private readonly ApplicationDataContainer _localSettings;
		#endregion

		public StorageSettingsService()
		{
			_localSettings = ApplicationData.Current.LocalSettings;
		}

		#region Generic
		public dynamic Get<T>(String key)
		{
			var value = _localSettings.Values[key];
			if (value == null)
				return null;
			else
				return (T)value;
		}

		public void Set<T>(String key, T value)
		{
			_localSettings.Values[key] = value;
		}

		public void Remove(String key)
		{
			_localSettings.Values.Remove(key);
		}
		#endregion
	}
}
