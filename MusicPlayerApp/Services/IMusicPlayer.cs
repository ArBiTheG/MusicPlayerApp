using MusicPlayerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public interface IMusicPlayer
    {
        void Load(string path);
        void Play();
        void Pause();
        void Stop();
        void Seek(TimeSpan position);
        bool IsPlaying { get; }
        float Position { get; set; }
        TimeSpan Duration { get; }
        int Volume { get; set; }
    }
}
