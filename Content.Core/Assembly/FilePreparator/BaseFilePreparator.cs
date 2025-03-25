namespace Content.Core.Assembly.FilePreparator
{
    internal class BaseFilePreparator(AssemblyData data) : IFilePreparator
    {

        private readonly AssemblyData _data = data;

        public PreparedFile PrepareFile(BaseFile file)
        {
            Func<string, string> commentedText = (text) => $"\n#{text}";
            const int dividorLength = 80;
            const char dividorChar = '=';
            string dividor = new string(dividorChar, dividorLength);
            const string prefix = "  ├─ ";

            bool severalInfo =
                (file.Path    != null) ||
                (_data.Author != null) ||
                (file.Name    != null);

            Func<string, string> part = (label) =>
                commentedText(dividor) +
                commentedText($"[{label.ToUpper()}]") +

                $"{(file.Path    != null ? commentedText($"{prefix}Path:   {file.Path.Substring(0, _data.WorkFolderPath.Length)}") : null)}" +
                $"{(file.Name    != null ? commentedText($"{prefix}Name:   {file.Name}")    : null)}" +
                $"{(_data.Author != null ? commentedText($"{prefix}Author: {_data.Author}") : null)}" +
                                           commentedText($"{prefix}Time:   {DateTime.Now}")           +

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
