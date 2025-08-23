using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace MusicPlayerApp.Services
{
    public class MusicMetadataImage : IMusicImage
    {
        File _file;
        public MusicMetadataImage(string path)
        {
            _file = File.Create(path);
        }
        public byte[] ImageBytes
        {
            get
            {
                IPicture? picture = _file.Tag.Pictures?.FirstOrDefault();
                if (picture != null)
                {
                    return picture.Data.Data;
                }
                return [];
            }
        }
    }
}
