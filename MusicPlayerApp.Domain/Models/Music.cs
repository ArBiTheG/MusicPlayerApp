using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Domain.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string CoverPath { get; set; }
        public string Title { get; set; }
        public ICollection<string> Artists { get; set; }
        public string ArtistAlbum { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }
        public int Number { get; set; }
        public ICollection<string> Genres { get; set; }
        public TimeSpan Duration { get; set; }
        public Music()
        {
            Path = string.Empty;
            CoverPath = string.Empty;
            Title = string.Empty;
            Artists = new List<string>();
            ArtistAlbum = string.Empty;
            Album = string.Empty;
            Genres = new List<string>();
        }

    }
}
