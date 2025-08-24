using MusicPlayerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public class MusicService
    {
        private readonly IMusicMetadataLoader musicLoader;
        public MusicService(IMusicMetadataLoader musicDataLoader)
        {
            musicLoader = musicDataLoader;
        }
        public Music Open(string path)
        {
            return musicLoader.Load(path);
        }
    }
}
