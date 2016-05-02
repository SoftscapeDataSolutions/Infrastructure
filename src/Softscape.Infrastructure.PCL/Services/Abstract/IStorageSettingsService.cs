using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softscape.Infrastructure.PCL.Services.Abstract
{
	public interface IStorageSettingsService
	{
		dynamic Get<T>(String key);

		void Set<T>(String key, T value);

		void Remove(String key);
	}
}
