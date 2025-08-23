using Avalonia.Media.Imaging;
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
    public class MusicMetadata : IMusicData
    {
        File _file;
        public MusicMetadata(string path)
        {
            _file = File.Create(path);
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

    }
}
