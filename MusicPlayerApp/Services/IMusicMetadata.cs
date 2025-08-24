using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public interface IMusicMetadata
    {
        string Title { get; }
        IEnumerable<string> Artists { get; }
        string Album { get; }
        IEnumerable<string> Genres { get; }
        int Year { get; }
    }
}
