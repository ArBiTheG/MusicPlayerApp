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
    public class MusicMetadataImage : IMusicImage
    {
        private readonly File _file;
        public MusicMetadataImage(string path)
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

        public byte[] GetBytes()
        {
            IPicture? picture = _file.Tag.Pictures.FirstOrDefault();
            return picture?.Data.Data ?? Array.Empty<byte>();
        }

        public async Task<byte[]> GetBytesAsync()
        {
            return await Task.FromResult(GetBytes());
        }
    }
}
