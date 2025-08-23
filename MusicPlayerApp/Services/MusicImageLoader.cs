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
        protected readonly Func<string, IMusicImage> CreateImage;
        public MusicImageLoader(Func<string, IMusicImage> createMetadata)
        {
            CreateImage = createMetadata;
        }

        public byte[] LoadBytes(string path)
        {
            IMusicImage metadata = CreateImage(path);
            return metadata.ImageBytes;
        }
    }
}
