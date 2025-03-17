using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Core.Assembly.FilePreparator
{
    internal class BaseFilePreparator(AssemblyData data) : IFilePreparator
    {

        private readonly AssemblyData _data = data;

        public PreparedFile PrepareFile(BaseFile file)
        {
            Func<string, string> commentedText = (text) => $"\n#{text}";
            const int dividorLength = 38;
            const char dividorChar = '=';
            string dividor = new string(dividorChar, dividorLength);

            bool severalInfo = (file.Path != null) || (_data.Author != null);

            Func<string, string> part = (label) =>
                commentedText(dividor) +
                commentedText($"[{label.ToUpper()}]") +

                $"{(file.Path != null? commentedText(file.Path.Substring(0, _data.WorkFolderPath.Length)) : null)}" +
                $"{(_data.Author != null ? commentedText($" Author: {_data.Author}") : null)}" +
                $"{(severalInfo? commentedText($"[{label.ToUpper()}]") : null)}" +

                commentedText($"{dividor} \n");

            return new PreparedFile(file)
            {
                Head = part("start"),
                Footer = part("end")
            };
        }
    }
}
