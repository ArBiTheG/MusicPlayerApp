using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerApp.Exceptions
{
    public class MetadataException : Exception
    {
        public MetadataException()
        {
        }

        public MetadataException(string? message) : base(message)
        {
        }

        public MetadataException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MetadataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
