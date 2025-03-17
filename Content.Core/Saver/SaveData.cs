using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Core.Saver
{
    internal class SaveData(string outPath)
    {
        public string OutputPath { get; set; } = outPath;

        public OnFileAlreadyExistOperation FileAlreadyExistOperation { get; set; } = OnFileAlreadyExistOperation.CreateWithIndex;
    }

    public enum OnFileAlreadyExistOperation
    {
        Overwrite,
        CreateWithIndex,
        ThrowEx
    }
}
