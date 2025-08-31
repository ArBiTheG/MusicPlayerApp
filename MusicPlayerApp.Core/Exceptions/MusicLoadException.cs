using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Core.Exceptions
{
    public class MusicLoadException : Exception
    {
        public MusicLoadException()
        {
        }

        public MusicLoadException(string? message) : base(message)
        {
        }

        public MusicLoadException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
