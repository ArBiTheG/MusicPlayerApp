using LibVLCSharp.Shared;
using MusicPlayerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Services.MusicPlayer
{
    public class VlcMusicPlayer : IMusicPlayer, IDisposable
    {
        private readonly LibVLC _libVLC;
        private readonly MediaPlayer _mediaPlayer;

        public VlcMusicPlayer(LibVLC libVLC, MediaPlayer mediaPlayer)
        {
            Core.Initialize();
            _libVLC = libVLC;
            _mediaPlayer = mediaPlayer;

            _mediaPlayer.Playing += mediaPlayer_Playing;
            _mediaPlayer.Paused += mediaPlayer_Paused;
            _mediaPlayer.Stopped += mediaPlayer_Stopped;
            _mediaPlayer.TimeChanged += mediaPlayer_TimeChanged;
            _mediaPlayer.EndReached += mediaPlayer_EndReached;
        }

        private void mediaPlayer_Playing(object? sender, EventArgs e)
        {
            MusicStarted?.Invoke(this, EventArgs.Empty);
        }
        private void mediaPlayer_Paused(object? sender, EventArgs e)
        {
            MusicPaused?.Invoke(this, EventArgs.Empty);
        }
        private void mediaPlayer_Stopped(object? sender, EventArgs e)
        {
            MusicStoped?.Invoke(this, EventArgs.Empty);
        }
        private void mediaPlayer_TimeChanged(object? sender, MediaPlayerTimeChangedEventArgs e)
        {
            TimeChanged?.Invoke(this, e.Time);
        }

        private void mediaPlayer_EndReached(object? sender, EventArgs e)
        {
            MusicFinished?.Invoke(this, EventArgs.Empty);
        }

        public bool IsPlaying => _mediaPlayer.IsPlaying;

        public long Position
        { 
            get => _mediaPlayer.Time; 
            set => _mediaPlayer.Time = value;
        }

        public long Duration => _mediaPlayer.Length;

        public int Volume 
        { 
            get => _mediaPlayer.Volume;
            set => _mediaPlayer.Volume = Math.Clamp(value, 0, 100);
        }

        public void Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Путь до файла не может быть пустым");

            string fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
                throw new ArgumentException("Указанный файл не найден");


            using (var media = new Media(_libVLC, new Uri(fullPath), ":no-video"))
            {
                _mediaPlayer.Media = media;
            }
            MusicLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void Play() => _mediaPlayer.Play();
        public void Pause() => _mediaPlayer.Pause();
        public void Stop() => _mediaPlayer.Stop();

        public event EventHandler MusicLoaded;
        public event EventHandler MusicStarted;
        public event EventHandler MusicPaused;
        public event EventHandler MusicStoped;
        public event EventHandler MusicFinished;
        public event EventHandler<long> TimeChanged;

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
            }
            disposed = true;
        }
    }
}
