namespace Content.Core
{
    internal class BaseFile
    {
        public BaseFile(string fileContent) => FileContent = fileContent;
        public BaseFile(string fileContent, string? path) : this(fileContent) => Path = path;

        public string FileContent { get; protected set; }
        public string? Path {get; private set; }
    }
}
