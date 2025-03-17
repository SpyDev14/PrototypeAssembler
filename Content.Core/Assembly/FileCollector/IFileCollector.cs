using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Core.Assembly.FileCollector
{
    internal interface IFileCollector
    {
        public BaseFile[] CollectFiles(string path);
    }
}
