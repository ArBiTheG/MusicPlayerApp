using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Core.Interfaces.Loaders
{
    public interface IImageLoader
    {
        Stream Load(string path);
    }
}
