using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Softscape.Infrastructure.WP8Silverlight.Security
{
	public static class SecureStorage
	{
		/// <summary>
		/// Removes an encrypted setting value
		/// </summary>
		/// <param name="key">Key to remove</param>
		public static void RemoveEncryptedSettingValue(string key)
		{
			if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
			{
				IsolatedStorageSettings.ApplicationSettings.Remove(key);
				IsolatedStorageSettings.ApplicationSettings.Save();
			}
		}

		/// <summary>
		/// Loads an encrypted setting value for a given key
		/// </summary>
		/// <param name="key">The key to load</param>
		/// <returns>
		/// The value of the key
		/// </returns>
		/// <exception cref="KeyNotFoundException">The given key was not found</exception>
		public static string LoadEncryptedSettingValue(string key)
		{
			string value = null;
			if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
			{
				var protectedBytes = IsolatedStorageSettings.ApplicationSettings[key] as byte[];
				if (protectedBytes != null)
				{
					byte[] valueBytes = ProtectedData.Unprotect(protectedBytes, null);
					value = Encoding.UTF8.GetString(valueBytes, 0, valueBytes.Length);
				}
			}

			return value;
		}

		public static T LoadEncryptedSettingValue<T>(string key) where T : class
		{
			T value = null;
			if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
			{
				var protectedBytes = IsolatedStorageSettings.ApplicationSettings[key] as byte[];
				if (protectedBytes != null)
				{
					var valueBytes = ProtectedData.Unprotect(protectedBytes, null);
					var valueString = Encoding.UTF8.GetString(valueBytes, 0, valueBytes.Length);

					if (!String.IsNullOrWhiteSpace(valueString))
					{
						value = JsonConvert.DeserializeObject<T>(valueString);
					}
				}
			}

			return value;
		}

		/// <summary>
		/// Saves a setting value against a given key, encrypted
		/// </summary>
		/// <param name="key">The key to save against</param>
		/// <param name="value">The value to save against</param>
		/// <exception cref="System.ArgumentOutOfRangeException">The key or value provided is unexpected</exception>
		public static void SaveEncryptedSettingValue(string key, string value)
		{
			if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
			{
				byte[] valueBytes = Encoding.UTF8.GetBytes(value);

				// Encrypt the value by using the Protect() method.
				byte[] protectedBytes = ProtectedData.Protect(valueBytes, null);
				if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
				{
					IsolatedStorageSettings.ApplicationSettings[key] = protectedBytes;
				}
				else
				{
					IsolatedStorageSettings.ApplicationSettings.Add(key, protectedBytes);
				}

				IsolatedStorageSettings.ApplicationSettings.Save();
			}
			else
			{
				throw new ArgumentOutOfRangeException();
			}
		}

		public static void SaveEncryptedSettingValue<T>(string key, T obj)
		{
			var valueString = JsonConvert.SerializeObject(obj);

			var valueBytes = Encoding.UTF8.GetBytes(valueString);

			// Encrypt the value by using the Protect() method.
			var protectedBytes = ProtectedData.Protect(valueBytes, null);
			if (IsolatedStorageSettings.ApplicationSettings.Contains(key))
			{
				IsolatedStorageSettings.ApplicationSettings[key] = protectedBytes;
			}
			else
			{
				IsolatedStorageSettings.ApplicationSettings.Add(key, protectedBytes);
			}

			IsolatedStorageSettings.ApplicationSettings.Save();
		}
	}
}
