using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using MusicPlayerApp.Core.Interfaces.Loaders;
using MusicPlayerApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.UI.ViewModels
{
    public partial class MusicViewModel: ViewModelBase
    {
        private Music? _music;
        private IImageLoader? _imageLoader;

        [ObservableProperty]
        private Bitmap? _cover;

        public MusicViewModel()
        {
            
        }
        public MusicViewModel(Music music, IImageLoader? imageLoader)
        {
            _music = music;
            _imageLoader = imageLoader;
        }


        public string Title => _music?.Title ?? "Unknown";
        public string Artist => _music?.GetFirstArtist() ?? "Unknown";

        public async Task LoadCover()
        {
            if (_imageLoader == null)
                return;

            if (_music == null)
                return;

            using (var stream = _imageLoader.Load(_music.Path))
            {
                Cover = await Task.Run(() => Bitmap.DecodeToWidth(stream, 128));
            }
        }
    }
}
