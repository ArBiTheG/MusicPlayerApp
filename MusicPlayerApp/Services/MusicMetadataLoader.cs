using MusicPlayerApp.Models;
using MusicPlayerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public class MusicMetadataLoader: IMusicMetadataLoader
    {
        protected readonly Func<string, IMusicMetadata> CreateMetadata;
        public MusicMetadataLoader(Func<string, IMusicMetadata> createMetadata)
        {
            CreateMetadata = createMetadata;
        }
        public Music Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Путь до файла не может быть пустым");

            string fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
                throw new ArgumentException("Указанный файл не найден");

            IMusicMetadata metadata = CreateMetadata(path);
            return new Music()
            {
                Path = path,
                Title = metadata.Title,
                Album = metadata.Album,
                Artists = metadata.Artists
            };
        }
    }
}
