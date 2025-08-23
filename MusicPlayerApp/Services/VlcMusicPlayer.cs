using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services
{
    public class VlcMusicPlayer : IDisposable, IMusicPlayer
    {
        private readonly LibVLC _libVLC;
        private readonly MediaPlayer _mediaPlayer;
        Media? _currentMedia;

        public VlcMusicPlayer(LibVLC libVLC, MediaPlayer mediaPlayer)
        {
            _libVLC = libVLC;
            _mediaPlayer = mediaPlayer;
        }

        public bool IsPlaying => _mediaPlayer.IsPlaying;

        public float Position
        { 
            get => _mediaPlayer.Position; 
            set => _mediaPlayer.Position = Math.Clamp(value, 0f,1f);
        }

        public TimeSpan Duration => TimeSpan.FromMilliseconds(_mediaPlayer.Length);

        public int Volume 
        { 
            get => _mediaPlayer.Volume;
            set => _mediaPlayer.Position = Math.Clamp(value, 0, 100);
        }

        public void Pause()
        {
            _mediaPlayer.Pause();
        }

        public void Play(string path)
        {
            _currentMedia?.Dispose();
            _currentMedia = new Media(_libVLC, new Uri(path));
            _currentMedia.AddOption(":no-video");
            _mediaPlayer.Play(_currentMedia);
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
                _libVLC.Dispose();
                _mediaPlayer.Dispose();
                _currentMedia?.Dispose();
            }
            disposed = true;
        }
    }
}
