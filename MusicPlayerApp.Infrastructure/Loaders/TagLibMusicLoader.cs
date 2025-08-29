using MusicPlayerApp.Domain.Exceptions;
using MusicPlayerApp.Domain.Interfaces.Loaders;
using MusicPlayerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagFile = TagLib.File;

namespace MusicPlayerApp.Infrastructure.Loaders
{
    public class TagLibMusicLoader : IMusicLoader
    {
        public Music Load(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("Путь до файла не может быть пустым");
            
            string fullPath = Path.GetFullPath(path);
            if (!File.Exists(fullPath))
                throw new ArgumentException("Указанный файл не найден");

            try
            {
                using TagFile file = TagFile.Create(fullPath);

                var tag = file?.Tag;
                var prop = file?.Properties;

                return new Music()
                {
                    Path = path,
                    Title = tag?.Title ?? string.Empty,
                    Artists = tag?.Performers ?? Array.Empty<string>(),
                    ArtistAlbum = tag?.FirstAlbumArtist ?? string.Empty,
                    Album = tag?.Album ?? string.Empty,
                    Year = (int)(tag?.Year ?? 0),
                    Number = (int)(tag?.TrackCount ?? 0),
                    Genres = tag?.Genres ?? Array.Empty<string>(),
                    Duration = prop?.Duration ?? TimeSpan.Zero,
                };
            }
            catch
            {
                throw new MusicLoadException("Не удалось загрузить данные музыки");
            }
        }
    }
}
