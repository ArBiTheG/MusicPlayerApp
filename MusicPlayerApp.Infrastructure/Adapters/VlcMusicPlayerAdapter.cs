using LibVLCSharp.Shared;
using MusicPlayerApp.Core.Interfaces;
using MusicPlayerApp.Core.Interfaces.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Infrastructure.Adapters
{
    public class VlcMusicPlayerAdapter : IMusicPlayerAdapter
    {
        private const string NO_VIDEO = ":no-video";

        private readonly MediaPlayer _mediaPlayer;
        private readonly LibVLC _libVLC;

        public VlcMusicPlayerAdapter(MediaPlayer mediaPlayer, LibVLC libVLC)
        {
            _mediaPlayer = mediaPlayer;
            _libVLC = libVLC;
        }

        public bool IsPlaying => _mediaPlayer.IsPlaying;

        public int Volume
        {
            get => _mediaPlayer.Volume;
            set => _mediaPlayer.Volume = Math.Clamp(value, 0, 100);
        }

        public void Open(string path)
        {
            using (var media = new Media(_libVLC, new Uri(path), NO_VIDEO))
            {
                _mediaPlayer.Media = media;
            }
        }

        public bool Play() => _mediaPlayer.Play();

        public void Pause() => _mediaPlayer.Pause();

        public void Stop() => _mediaPlayer.Stop();
    }
}
