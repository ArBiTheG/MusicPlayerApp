using Avalonia.Media.Imaging;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using File = TagLib.File;

namespace MusicPlayerApp.Services
{
    public class MusicMetadata : IMusicData, IDisposable
    {
        private readonly File _file;
        public MusicMetadata(string path)
        {
            try
            {
                _file = File.Create(path);
            }
            catch
            {
                throw new IOException($"Не удалось открыть файл '{path}' для чтения метаданных");
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
