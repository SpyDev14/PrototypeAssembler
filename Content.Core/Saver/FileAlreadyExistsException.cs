using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Core.Saver
{
    internal class FileAlreadyExistsException : Exception
    {
        public FileAlreadyExistsException() : base() {}

        public FileAlreadyExistsException(string? message) : base(message) { }

        public FileAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
