using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeAssembler.Shared.Assembly.FilePreparator
{
    internal class PreparedFile : DefaultFile
    {
        public PreparedFile(string content) : base(content) { }

        public PreparedFile(string content, string name) : base(content, name) { }

        public PreparedFile(DefaultFile defaultFile) : base(defaultFile.Content)
        {
            Name = defaultFile.Name;
        }

        public string? Head { get; set; }

        public string? Footer { get; set; }

        public override string ToString()
        {
            return $"{Head}\n{Content}\n{Footer}";
        }
    }
}
