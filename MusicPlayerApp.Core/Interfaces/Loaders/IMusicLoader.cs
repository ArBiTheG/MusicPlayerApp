using MusicPlayerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Core.Interfaces.Loaders
{
    public interface IMusicLoader
    {
        Music Load(string path);
    }
}
