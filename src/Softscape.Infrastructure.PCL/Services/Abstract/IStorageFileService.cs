using System;
using System.Threading.Tasks;

namespace Softscape.Infrastructure.PCL.Services.Abstract
{

//TODO
//http://codepaste.net/gtu5mq

	public interface IStorageFileService
	{
		Task StoreFileAsync(String fileName, byte[] fileBytes);
		Task StoreFileAsync(String fileName, String data);
		Task StoreFileAsync<T>(String fileName, T entity);

		Task<byte[]> GetFileAsByteArrayAsync(String fileName);
		Task<String> GetFileAsStringAsync(String fileName);
		Task<T> GetFileAsAsync<T>(String fileName);

		Task<Boolean> ExistsAsync(String fileName);
	}
}
