using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using MusicPlayerApp.Models;
using MusicPlayerApp.Services;
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

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _artists;

        [ObservableProperty]
        private Bitmap? _cover;

        public MusicViewModel(Music music)
        {
            _music = music;
            Name = _music.Name;
            Artists = string.Join(",", _music.Artist);
            Cover = LoadImage(_music.Path);
        }

        public Bitmap? LoadImage(string path)
        {
            IImageLoader imageLoader = new ImageMetadataLoader();
            byte[] bytes = imageLoader.LoadBytes(path);
            if (bytes.Length>0)
            {
                using MemoryStream memoryStream = new MemoryStream(bytes);
                return new Bitmap(memoryStream);
            }
            return null;
        }
    }
}
