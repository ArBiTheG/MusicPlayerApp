using Avalonia.Controls.Shapes;
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
        private IMusicImageLoader? _imageLoader;

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _artists;

        [ObservableProperty]
        private Bitmap? _cover;

        public MusicViewModel(Music music)
        {
            _music = music;

            Title = _music.Title;
            Artists = string.Join(",", _music.Artists);
        }

        public MusicViewModel(Music music, IMusicImageLoader imageLoader): this(music)
        {
            _imageLoader = imageLoader;
        }

        public void LoadImage()
        {
            if (_imageLoader!=null)
                Cover = LoadImage(_imageLoader, _music.Path);
        }

        private static Bitmap? LoadImage(IMusicImageLoader imageLoader, string path)
        {
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
