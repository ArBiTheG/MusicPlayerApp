using MusicPlayerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public interface IMusicLoader
    {
        Music Load(string path);
    }
}
