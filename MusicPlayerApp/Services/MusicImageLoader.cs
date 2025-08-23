using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public class MusicImageLoader: IMusicImageLoader
    {
        protected readonly Func<string, IMusicMetadata> CreateMetadata;
        public MusicImageLoader(Func<string, IMusicMetadata> createMetadata)
        {
            CreateMetadata = createMetadata;
        }

        public byte[] LoadBytes(string path)
        {
            IMusicMetadata metadata = CreateMetadata(path);
            return metadata.ImageBytes;
        }
    }
}
