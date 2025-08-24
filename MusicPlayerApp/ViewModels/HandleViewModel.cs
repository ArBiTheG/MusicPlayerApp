using CommunityToolkit.Mvvm.ComponentModel;
using MusicPlayerApp.Models;
using MusicPlayerApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.ViewModels
{
    public partial class HandleViewModel: ViewModelBase
    {
        [ObservableProperty]
        private MusicViewModel? _currentMusic;

        private MusicService? _musicService;
        private IMusicPlayer? _musicPlayer;
        private IMusicImageLoader? _musicImageLoader;

        public HandleViewModel()
        {

        }

        public HandleViewModel(MusicService musicService, IMusicPlayer musicPlayer, IMusicImageLoader musicImageLoader)
        {
            _musicService = musicService;
            _musicPlayer = musicPlayer;
            _musicImageLoader = musicImageLoader;
        }

        private void AddMusic(string path)
        {
            if (_musicService == null)
                return;

            var music = _musicService.Open(path);

            CurrentMusic = new MusicViewModel(music, _musicImageLoader);
            CurrentMusic.LoadCover();
        }

        public string Greeting { get; } = "Welcome to Avalonia!";
    }
}
