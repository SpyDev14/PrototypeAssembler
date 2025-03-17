using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Core.Assembly.FilePreparator
{
    internal interface IFilePreparator
    {
        public PreparedFile PrepareFile(DefaultFile file);
    }
}
