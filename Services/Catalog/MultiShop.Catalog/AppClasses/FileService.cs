using MultiShop.Catalog.DTOs.Image;
using System.Collections.Generic;
using System.IO;

namespace MultiShop.Catalog.AppClasses
{
    public static class FileService
    {
        public static string ConvertBase64(string path, string name)
        {

            string imagePath = Path.Combine(path, name);
            byte[] imagesBytes = System.IO.File.ReadAllBytes(imagePath);
            return $"data:image/jpeg;base64,{Convert.ToBase64String(imagesBytes)}";

        }
        public static async Task<List<string>> UploadAsync(IFormFileCollection formFiles, string path)
        {
            string _path = Path.Combine("wwwroot", path);
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
            var files = formFiles.ToList();

            List <string> r_path=new List<string> ();

            foreach (var file in files)
            {
                string newFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string fullpath = Path.Combine(Directory.GetCurrentDirectory(), _path, newFileName);
                await using FileStream fileStream = new(fullpath, FileMode.Create, FileAccess.Write, FileShare.None, (500 * 500), true);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

                r_path.Add(Path.Combine(_path, newFileName));

            }
            return r_path;
        }
        public static async Task DeleteAsync(string path, string name)
                             => File.Delete($"{path}\\{name}");

    }
}
