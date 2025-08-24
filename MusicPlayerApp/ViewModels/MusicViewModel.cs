using Avalonia.Controls.Shapes;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using MusicPlayerApp.Models;
using MusicPlayerApp.Services;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.ViewModels
{
    public partial class MusicViewModel: ViewModelBase
    {
        private Music _music;
        private IMusicImageLoader? _imageLoader;

        private Bitmap? _сover;

        public MusicViewModel(Music music, IMusicImageLoader? imageLoader)
        {
            _music = music;
            _imageLoader = imageLoader;
        }

        public string Title => _music.Title;
        public string Artists => string.Join(",", _music.Artists);
        public Bitmap? Cover
        {
            get => _сover;
            private set => SetProperty(ref _сover, value);
        }

        public async Task LoadCover()
        {
            if (_imageLoader == null)
                return;

            await using (var imageStream = await _imageLoader.LoadAsync(_music.Path))
            {
                Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 128));
            }
        }
    }
}
