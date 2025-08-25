using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicPlayerApp.Models;
using MusicPlayerApp.Services;
using MusicPlayerApp.Services.MusicPlayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.ViewModels
{
    public partial class HandleViewModel: ViewModelBase
    {
        private MusicService? _musicService;
        private IMusicPlayer? _musicPlayer;
        private IMusicImageLoader? _musicImageLoader;

        [ObservableProperty]
        private bool _isPaneOpen  =true;

        [ObservableProperty]
        private MusicViewModel? _currentMusic;

        [ObservableProperty]
        private ObservableCollection<MusicViewModel> _musicList;

        [ObservableProperty]
        private int _progressMusic;

        [ObservableProperty]
        private int _volumeMusic;

        public HandleViewModel()
        {
            _musicList = new ObservableCollection<MusicViewModel>();
        }

        public HandleViewModel(MusicService musicService, IMusicPlayer musicPlayer, IMusicImageLoader musicImageLoader)
        {
            _musicList = new ObservableCollection<MusicViewModel>();

            _musicService = musicService;
            _musicPlayer = musicPlayer;
            _musicImageLoader = musicImageLoader;
        }

        [RelayCommand]
        private void PaneOpenClose()
        {
            IsPaneOpen = !IsPaneOpen;
        }

        [RelayCommand]
        private async Task LoadAsync()
        {
            if (_musicService == null)
                return;

            if (_musicPlayer == null)
                return;

            Music music = _musicService.Open(@"Skillet_-_Hero_47950055.mp3");
            _musicPlayer.Load(music.Path);
            CurrentMusic = new MusicViewModel(music, _musicImageLoader);
            await CurrentMusic.LoadCover();
        }


        [RelayCommand]
        private async Task AddMusicAsync()
        {
            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task PlayPauseMusicAsync()
        {
            if (_musicPlayer == null)
                return;

            if (!_musicPlayer.IsPlaying)
                _musicPlayer.Play();
            else
                _musicPlayer.Pause();

            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task StopMusicAsync()
        {
            if (_musicPlayer == null)
                return;

            _musicPlayer.Stop();

            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task PreviousMusicAsync()
        {
            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task NextMusicAsync()
        {
            await Task.CompletedTask;
        }

        partial void OnProgressMusicChanged(int value)
        {
            if (_musicPlayer == null)
                return;
            //_musicPlayer.Position = (float)value/100;
        }
        partial void OnVolumeMusicChanged(int value)
        {
            if (_musicPlayer == null)
                return;
            _musicPlayer.Volume = value;
        }
    }
}
