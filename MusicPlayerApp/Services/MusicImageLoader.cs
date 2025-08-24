using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public class MusicImageLoader: IMusicImageLoader
    {
        protected readonly Func<string, IMusicImage> CreateImage;
        public MusicImageLoader(Func<string, IMusicImage> createMetadata)
        {
            CreateImage = createMetadata;
        }
        public Stream Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Путь до файла не может быть пустым");

            string fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
                throw new ArgumentException("Указанный файл не найден");

            IMusicImage metadata = CreateImage(path);
            return new MemoryStream(metadata.GetBytes());
        }

        public async Task<Stream> LoadAsync(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Путь до файла не может быть пустым");

            string fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
                throw new ArgumentException("Указанный файл не найден");

            IMusicImage metadata = CreateImage(path);
            return new MemoryStream(await metadata.GetBytesAsync());
        }
    }
}
