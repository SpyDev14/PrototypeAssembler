namespace Content.Core.Assembly.FilePreparator;

internal class BaseFilePreparator(AssemblyData data) : IFilePreparator
{

    private readonly AssemblyData _data = data;

    public PreparedFile PrepareFile(BaseFile file)
    {
        const int dividorLength = 80;
        const char dividorChar = '-';
        const string prefix = "  ├─ ";

        Func<string, string> commentText = (text) => $"\n# {text}";
        Func<string, string> getDividor = (label) => new string(dividorChar, dividorLength - (label.Length+3));
        
        bool severalInfo =
            (file.Path    != null) ||
            (file.Name    != null) ||
            (_data.Author != null) ;

        Func<string, string> part = (label) =>
            commentText($"[{label.ToUpper()}] {getDividor(label)}") +
                $"{(file.Path    != null ? commentText($"{prefix}Path:   {file.Path.Substring(0, _data.WorkFolderPath.Length)}") : null)}" +
                $"{(file.Name    != null ? commentText($"{prefix}Name:   {file.Name}")    : null)}" +
                $"{(_data.Author != null ? commentText($"{prefix}Author: {_data.Author}") : null)}" +
            $"{(severalInfo ? commentText($"[{label.ToUpper()}] {getDividor(label)}") : null)}\n";

        return new PreparedFile(file)
        {
            Head = part("start"),
            Footer = part("end")
        };
    }
}