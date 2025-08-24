using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public interface IMusicImageLoader
    {
        Stream Load(string path);
        Task<Stream> LoadAsync(string path);
    }
}
