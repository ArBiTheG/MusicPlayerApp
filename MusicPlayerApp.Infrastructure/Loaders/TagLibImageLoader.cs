using MusicPlayerApp.Domain.Exceptions;
using MusicPlayerApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagFile = TagLib.File;

namespace MusicPlayerApp.Infrastructure.Loaders
{
    public class TagLibImageLoader : IImageLoader
    {
        public Stream Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Путь до файла не может быть пустым");

            string fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
                throw new ArgumentException("Указанный файл не найден");


            try
            {
                using TagFile file = TagFile.Create(fullPath);
                var tag = file?.Tag;
                if (tag == null) 
                    return Stream.Null;

                var picture = tag.Pictures.FirstOrDefault();
                if (picture == null)
                    return Stream.Null;

                var bytes = picture.Data?.Data;
                if (bytes == null)
                    return Stream.Null;
                if (bytes.Length == 0)
                    return Stream.Null;

                return new MemoryStream(bytes, writable: false);
            }
            catch
            {
                throw new ImageLoadException("Не удалось загрузить изображение");
            }
        }
    }
}
