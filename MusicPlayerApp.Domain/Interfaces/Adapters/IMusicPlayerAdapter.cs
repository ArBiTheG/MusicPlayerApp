using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Domain.Interfaces.Adapters
{
    public interface IMusicPlayerAdapter: IDisposable
    {
        bool IsPlaying { get; }
        int Volume { get; set; }

        void Open(string path);
        bool Play();
        void Pause();
        void Stop();
    }
}
