using Avalonia.Media.Imaging;
using LibVLCSharp.Shared;
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
    public class MusicMetadata : IMusicMetadata
    {
        public string Title { get; }
        public string Album { get; }
        public int Year { get; }
        public IEnumerable<string> Artists { get; }
        public IEnumerable<string> Genres { get; }

        public MusicMetadata(string path)
        {
            try
            {
                using var file = File.Create(path);
                var tag = file.Tag;

                Title = tag.Title;
                Album = tag.Album;
                Year = (int)tag.Year;
                Artists = tag.Performers.ToArray();
                Genres = tag.Genres.ToArray();
            }
            catch
            {
                throw new MetadataException($"Не удалось открыть файл '{path}' для чтения метаданных");
            }
        }
    }
}
