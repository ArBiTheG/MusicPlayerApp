using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Domain.Exceptions
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

        protected MusicLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
