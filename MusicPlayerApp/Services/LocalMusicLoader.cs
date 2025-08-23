using MusicPlayerApp.Models;
using MusicPlayerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public class LocalMusicLoader: IMusicLoader
    {
        protected readonly Func<string, IMusicMetadata> CreateMetadata;
        public LocalMusicLoader(Func<string, IMusicMetadata> createMetadata)
        {
            CreateMetadata = createMetadata;
        }
        public Music Load(string path)
        {
            IMusicMetadata metadata = CreateMetadata(path);
            return new Music()
            {
                Path = path,
                Name = metadata.Title,
                Album = metadata.Album,
                Artist = metadata.Artist
            };
        }
    }
}
