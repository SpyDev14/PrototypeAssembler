using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Core.Assembly.FilePreparator
{
    internal class DefaultFilePreparator(AssemblyData data) : IFilePreparator
    {
        public PreparedFile PrepareFile(DefaultFile file)
        {
            Func<string, string> commentedText = (text) => $"\n#{text}";
            const int dividorLength = 38;
            const char dividorChar = '=';
            string dividor = new string(dividorChar, dividorLength);
            string? author = data.Author;

            Func<string, string> part = (label) =>
                commentedText(dividor) +
                commentedText($" <-- [{label.ToUpper()}] {(author != null ? $" Author: {author} [{label.ToUpper()}]" : null)}") +
                commentedText($"{dividor} \n");

            return new(file)
            {
                Head = part("start"),

                Footer = part("end")
            };
        }
    }
}
