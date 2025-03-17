using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Core.Saver
{
    internal class SaveData(string outPath, string assembledFileName)
    {
        public string OutputPath { get; set; } = outPath;

        public string AssembledFileName {  get; set; } = assembledFileName;

        public OnFileAlreadyExist OnFileAlreadyExistOperation { get; set; }
            = OnFileAlreadyExist.CreateWithIndex;
    }

    public enum OnFileAlreadyExist
    {
        Overwrite,
        CreateWithIndex,
        ThrowException
    }
}
