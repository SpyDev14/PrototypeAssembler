using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeAssembler.Shared.Assembly.FilePreparator
{
    internal class DefaultFilePreparator(AssemblyData data) : IFilePreparator
    {
        private readonly AssemblyData _data = data;

        public PreparedFile PrepareFile(DefaultFile file)
        {
            Func<string, string> commentedText = (text) => $"\n#{text}";
            const int dividorLength = 38;
            const char dividorChar = '=';

            Func<string, string> part = (suffix) =>
                commentedText(new string(dividorChar, dividorLength)) +
                commentedText($" <-- [{suffix.ToUpper()}] {(_data.AdAuthor ? $" Author: {_data.Author} [{suffix.ToUpper()}]" : null)}") +
                commentedText($"{new string(dividorChar, dividorLength)} \n");

            return new(file)
            {
                Head = part("start"),

                Footer = part("end")
            };
        }
    }
}
