namespace Content.Core
{
    internal class BaseFile
    {
        public BaseFile(string fileContent) => FileContent = fileContent;
        public string FileContent { get; protected set; }

    }
}
