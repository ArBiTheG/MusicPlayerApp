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

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _artists;

        [ObservableProperty]
        private Bitmap? _cover;

        public MusicViewModel(Music music, IMusicImageLoader? imageLoader)
        {
            _music = music;
            _imageLoader = imageLoader;

            Title = _music.Title;
            Artists = string.Join(",", _music.Artists);
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
