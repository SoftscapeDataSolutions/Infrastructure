using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Newtonsoft.Json;
using Softscape.Infrastructure.PCL.Services.Abstract;

namespace Softscape.Infrastructure.PCL.Services
{
	public class StorageFileService : IStorageFileService
	{
		public async Task StoreFileAsync(String fileName, byte[] fileBytes)
		{
			var imageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
			var fs = await imageFile.OpenAsync(FileAccessMode.ReadWrite);
			var outputStream = fs.GetOutputStreamAt(0);
			var writer = new DataWriter(outputStream);
			writer.WriteBytes(fileBytes);
			await writer.StoreAsync();
			writer.DetachStream();
			await fs.FlushAsync();
			fs.Dispose();

			//http://www.damirscorner.com/ClosingStreamsInWinRT.aspx
			outputStream.Dispose();

			writer.Dispose();
		}

		public async Task StoreFileAsync(String fileName, String data)
		{
			var imageFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
			var fs = await imageFile.OpenAsync(FileAccessMode.ReadWrite);
			var outputStream = fs.GetOutputStreamAt(0);
			var writer = new DataWriter(outputStream);
			writer.WriteString(data);
			await writer.StoreAsync();
			writer.DetachStream();
			await fs.FlushAsync();
			fs.Dispose();

			//http://www.damirscorner.com/ClosingStreamsInWinRT.aspx
			outputStream.Dispose();

			writer.Dispose();
		}

		public async Task StoreFileAsync<T>(String fileName, T entity)
		{
			var jsonString = JsonConvert.SerializeObject(entity);
			await StoreFileAsync(fileName, jsonString);
		}


		public async Task<byte[]> GetFileAsByteArrayAsync(String fileName)
		{
			var file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);

			var stream = await file.OpenReadAsync();

			byte[] data;
			using (var dataReader = new DataReader(stream))
			{
				data = new byte[stream.Size];
				await dataReader.LoadAsync((uint)stream.Size);
				dataReader.ReadBytes(data);
			}

			return data;
		}

		public async Task<String> GetFileAsStringAsync(String fileName)
		{
			var file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);

			var stream = await file.OpenReadAsync();

			String data;
			using (var dataReader = new DataReader(stream))
			{
				
				await dataReader.LoadAsync((uint)stream.Size);
				data = dataReader.ReadString((uint)stream.Size);
			}

			return data;
		}

		public async Task<T> GetFileAsAsync<T>(String fileName)
		{
			var json = await GetFileAsStringAsync(fileName);
			return JsonConvert.DeserializeObject<T>(json);
		}

		public async Task<Boolean> ExistsAsync(String fileName)
		{
			var exists = true;

			try
			{
				await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
			}
			catch (Exception)
			{
				exists = false;
			}

			return exists;
		}

//		public async Task DeleteFileAsync(String fileName)
//		{
//			throw new NotImplementedException();

//#if WINDOWS_APP
//			var sampleFile = await ApplicationData.Current.LocalFolder.TryGetItemAsync(fileName);

//			if (sampleFile != null)
//			{
//				await sampleFile.DeleteAsync(StorageDeleteOption.PermanentDelete);
//			}
//#endif
//		}

		public async Task<BitmapImage> GetImageAsync(String fileName)
		{
			var file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);

			var bitmapImage = new BitmapImage();
			var stream = (FileRandomAccessStream)await file.OpenAsync(FileAccessMode.Read);
			bitmapImage.SetSource(stream);

			return bitmapImage;
		}
	}
}
