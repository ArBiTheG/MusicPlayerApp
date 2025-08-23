using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public class MediaMusicPlayer : IDisposable, IMusicPlayer
    {
        LibVLC _libVLC;
        MediaPlayer _mediaPlayer;

        public MediaMusicPlayer()
        {
            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
        }

        public bool IsPlaying => _mediaPlayer.IsPlaying;

        public float Position
        { 
            get => _mediaPlayer.Position; 
            set
            {
                if (value < 0)
                    _mediaPlayer.Position = 0;
                else if (value > 1)
                    _mediaPlayer.Position = 1;
                else
                    _mediaPlayer.Position = value;
            }
        }

        public TimeSpan Duration => TimeSpan.FromMilliseconds(_mediaPlayer.Length);

        public int Volume 
        { 
            get => _mediaPlayer.Volume; 
            set {
                if (value < 0)
                    _mediaPlayer.Volume = 0;
                else if (value > 100)
                    _mediaPlayer.Volume = 100;
                else
                    _mediaPlayer.Volume = value;
            }
        }

        public void Pause()
        {
            _mediaPlayer.Pause();
        }

        public void Play(string path)
        {
            _mediaPlayer.Play(new Media(_libVLC, new Uri(path), ":no-video"));
        }

        public void Play()
        {
            _mediaPlayer.Play();
        }

        public void Seek(TimeSpan position)
        {
            _mediaPlayer.SeekTo(position);
        }

        public void Stop()
        {
            _mediaPlayer.Stop();
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                // Освобождаем управляемые ресурсы
            }
            _libVLC.Dispose();
            _mediaPlayer.Dispose();
            disposed = true;
        }
    }
}
