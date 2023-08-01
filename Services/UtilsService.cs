using System;
namespace Bookman.Services
{
	public static class UtilsService
	{
		public static string GetUniqueFileName(string fileName)
		{
			string extension = Path.GetExtension(fileName);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

			string uniqueFileName = $"{fileNameWithoutExtension.ToLower()}_{Guid.NewGuid()}{extension}";
			return uniqueFileName;
		}
	}
}

