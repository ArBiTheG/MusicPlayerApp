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
        private Music? _music;

        private MusicService? _musicService;
        private IMusicPlayer? _musicPlayer;

        public HandleViewModel()
        {

        }

        public HandleViewModel(MusicService musicService, IMusicPlayer musicPlayer)
        {
            _musicService = musicService;
            _musicPlayer = musicPlayer;

            Music = musicService.Open(@"Skillet_-_Hero_47950055.mp3");
        }

        public string Greeting { get; } = "Welcome to Avalonia!";
    }
}
