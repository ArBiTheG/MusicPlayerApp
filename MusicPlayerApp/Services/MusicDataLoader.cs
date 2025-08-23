using MusicPlayerApp.Models;
using MusicPlayerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public class MusicDataLoader: IMusicDataLoader
    {
        protected readonly Func<string, IMusicMetadata> CreateMetadata;
        public MusicDataLoader(Func<string, IMusicMetadata> createMetadata)
        {
            CreateMetadata = createMetadata;
        }
        public Music Load(string path)
        {
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
