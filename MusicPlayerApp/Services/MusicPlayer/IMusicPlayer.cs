using MusicPlayerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services.MusicPlayer
{
    public interface IMusicPlayer
    {
        void Load(string path);
        void Play();
        void Pause();
        void Stop();
        bool IsPlaying { get; }
        long Position { get; set; }
        long Duration { get; }
        int Volume { get; set; }

        event EventHandler MusicLoaded;
        event EventHandler MusicStarted;
        event EventHandler MusicPaused;
        event EventHandler MusicStoped;
        event EventHandler MusicFinished;
        event EventHandler<long> TimeChanged;
    }
}
