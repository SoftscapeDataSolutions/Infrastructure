using System;
using System.Text.RegularExpressions;

namespace Softscape.Infrastructure.WP8Silverlight.Validation
{
	public static class ValidationExtensions
	{
		public static bool IsValidEmail(string email)
		{
			if (String.IsNullOrWhiteSpace(email))
				return false;

			// Return true if strIn is in valid e-mail format.
			return Regex.IsMatch(email,
				   @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
				   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
		}

		public static bool IsValidPhone(string phone)
		{
			if (String.IsNullOrWhiteSpace(phone))
				return false;

			return phone.Length > 2;
		}
	}
}
