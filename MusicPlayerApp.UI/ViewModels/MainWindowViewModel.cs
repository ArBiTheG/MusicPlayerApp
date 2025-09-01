using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using MusicPlayerApp.Core.Interfaces.Adapters;
using MusicPlayerApp.Core.Interfaces.Loaders;
using MusicPlayerApp.Core.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MusicPlayerApp.UI.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly IMusicPlayerAdapter? _musicPlayer;
        private readonly IMusicLoader? _musicLoader;
        private readonly IImageLoader? _imageLoader;
        private readonly IConfiguration? _config;

        [ObservableProperty]
        private bool _isPaneOpen;

        [ObservableProperty]
        private bool _isPlaying;

        [ObservableProperty]
        private MusicViewModel? _currentMusic;

        [ObservableProperty]
        private ObservableCollection<MusicViewModel> _playlist;

        [ObservableProperty]
        private int _position;

        [ObservableProperty]
        private int _duration;

        [ObservableProperty]
        private int _volume;

        public MainWindowViewModel()
        {
            _playlist = new ObservableCollection<MusicViewModel>();
        }
        public MainWindowViewModel(IMusicPlayerAdapter musicPlayer, IMusicLoader musicLoader, IImageLoader imageLoader): this()
        {
            _musicPlayer = musicPlayer;
            _musicLoader = musicLoader;
            _imageLoader = imageLoader;
        }

        [RelayCommand]
        private async Task LoadAsync()
        {
            if (_config != null)
            {
                var path = _config["play"];
                if (path != null)
                {
                    if (_musicLoader != null)
                    {
                        var music = _musicLoader.Load(path);
                        CurrentMusic = new MusicViewModel(music, _imageLoader);
                        await CurrentMusic.LoadCover();
                        if (_musicPlayer != null)
                        {
                            var playing = _musicPlayer.Play();
                            IsPlaying = playing;
                        }
                    }
                }
            }
        }

        [RelayCommand]
        private async Task PlayPauseMusicAsync()
        {
            if (_musicPlayer == null)
                return;

            if (!IsPlaying)
            {
                var playing = _musicPlayer.Play();
                IsPlaying = playing;
            }
            else
            {
                _musicPlayer.Pause();
                IsPlaying = false;
            }

            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task StopMusicAsync()
        {
            if (_musicPlayer == null)
                return;

            _musicPlayer.Stop();
            IsPlaying = false;

            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task PreviousMusicAsync()
        {
            if (_musicPlayer == null)
                return;

            int firstIndex = 0;
            int lastIndex = Playlist.Count - 1;

            if (CurrentMusic != null)
                Playlist.Insert(firstIndex, CurrentMusic);

            CurrentMusic = Playlist[lastIndex];
            Playlist.RemoveAt(lastIndex);

            await Task.CompletedTask;
        }

        [RelayCommand]
        private async Task NextMusicAsync()
        {
            if (_musicPlayer == null)
                return;

            int firstIndex = 0;
            int lastIndex = Playlist.Count - 1;

            if (CurrentMusic != null)
                Playlist.Insert(lastIndex, CurrentMusic);

            CurrentMusic = Playlist[firstIndex];
            Playlist.RemoveAt(firstIndex);

            await Task.CompletedTask;
        }
    }
}
