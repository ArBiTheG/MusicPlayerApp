using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Domain.Exceptions
{
    public class ImageLoadException : Exception
    {
        public ImageLoadException()
        {
        }

        public ImageLoadException(string? message) : base(message)
        {
        }

        public ImageLoadException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
