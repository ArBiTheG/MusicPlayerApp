using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Models
{
    public class Music
    {
        public string Path { get; set; }
        public string Title { get; set; }
        public string[] Artists { get; set; }
        public string Album { get; set; }
        public string CoverUrl { get; set; }

    }
}
