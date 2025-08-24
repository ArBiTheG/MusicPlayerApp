using Avalonia.Media;
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

        private Stream GetMusicImageStream(string path)
        {
            IMusicImage metadata = CreateImage(path);
            Stream stream = metadata.GetImageStream();
            return new MusicImageStream(stream, metadata);
        }

        public Stream Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Путь до файла не может быть пустым");

            string fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
                throw new ArgumentException("Указанный файл не найден");

            return GetMusicImageStream(fullPath);
        }

        public async Task<Stream> LoadAsync(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Путь до файла не может быть пустым");

            string fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
                throw new ArgumentException("Указанный файл не найден");

            return await Task.FromResult(GetMusicImageStream(path));
        }
    }
}
