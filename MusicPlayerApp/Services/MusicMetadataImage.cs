using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using File = System.IO.File;
using MusicFile = TagLib.File;

namespace MusicPlayerApp.Services
{
    public class MusicMetadataImage : IMusicImage
    {
        private readonly MusicFile _file;
        public MusicMetadataImage(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Путь до файла не может быть пустым");

            string fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
                throw new ArgumentException("Указанный файл не найден");

            try
            {
                _file = MusicFile.Create(fullPath);
            }
            catch
            {
                throw new IOException($"Не удалось открыть файл '{fullPath}' для чтения метаданных");
            }
        }
        public byte[] ImageBytes
        {
            get
            {
                IPicture? picture = _file.Tag.Pictures?.FirstOrDefault();
                if (picture != null)
                {
                    return picture.Data.Data;
                }
                return [];
            }
        }
    }
}
