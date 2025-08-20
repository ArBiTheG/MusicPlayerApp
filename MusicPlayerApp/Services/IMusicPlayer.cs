using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public interface IMusicPlayer
    {
        void Play();
        void Pause();
        void Stop();
        void Seek(TimeSpan position);
        bool IsPlaying { get; }
        TimeSpan Position { get; }
        TimeSpan Duration { get; }
        float Volume { get; set; }
    }
}
