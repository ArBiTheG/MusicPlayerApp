using Avalonia.Media.Imaging;
using LibVLCSharp.Shared;
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
    public class MusicMetadata : IMusicData, IDisposable
    {
        private readonly MusicFile _file;
        public MusicMetadata(string path)
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
        public string Title 
        { 
            get => _file.Tag.Title; 
        }
        public string[] Artists
        {
            get => _file.Tag.Performers;
        }
        public string Album
        {
            get => _file.Tag.Album;
        }
        public string[] Genres 
        {
            get => _file.Tag.Genres;
        }
        public uint Year
        {
            get => _file.Tag.Year;
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                _file.Dispose();
            }
            disposed = true;
        }
    }
}
