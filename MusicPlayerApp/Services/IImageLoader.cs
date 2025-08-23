using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public interface IImageLoader
    {
        byte[] LoadBytes(string path);
    }
}
