using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public class ImageMetadataLoader: IImageLoader
    {
        public byte[] LoadBytes(string path)
        {
            IMusicMetadata metadata = new MusicMetadata(path);
            return metadata.ImageBytes;
        }
    }
}
