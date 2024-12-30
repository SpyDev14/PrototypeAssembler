using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeAssembler.Shared.Saver
{
    internal class FileAlreadyExistsEsception : Exception
    {
        public FileAlreadyExistsEsception() : base() {}

        public FileAlreadyExistsEsception(string? message) : base(message) { }

        public FileAlreadyExistsEsception(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
