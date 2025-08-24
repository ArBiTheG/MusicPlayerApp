using MusicPlayerApp.Exceptions;
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
    public class MusicImage : IMusicImage
    {
        private readonly File _file;
        private bool _disposed;

        public MusicImage(string path)
        {
            try
            {
                _file = File.Create(path);
            }
            catch
            {
                throw new MetadataException($"Не удалось открыть файл '{path}' для чтения метаданных");
            }
        }

        public Stream GetImageStream()
        {
            var picture = _file.Tag.Pictures.FirstOrDefault();
            if (picture == null)
                return Stream.Null;

            var bytes = picture.Data?.Data;
            if (bytes == null)
                return Stream.Null;
            if (bytes.Length == 0)
                return Stream.Null;

            return new MemoryStream(bytes, writable: false);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _file.Dispose();
            _disposed = true;
        }
    }
}
