using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Core.Interfaces.Adapters
{
    public interface IMusicPlayerAdapter
    {
        bool IsPlaying { get; }
        int Volume { get; set; }

        void Open(string path);
        bool Play();
        void Pause();
        void Stop();
    }
}
