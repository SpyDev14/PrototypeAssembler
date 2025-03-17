namespace Content.Core.Assembly.FilePreparator
{
    internal class PreparedFile : BaseFile
    {
        public PreparedFile(string fileContent) : base(fileContent) { }
        public PreparedFile(string fileContent, string? path) : base(fileContent, path) {}
        public PreparedFile(BaseFile file) : this(file.FileContent, file.Path) {}

        public string? Head { get; set; }

        public string? Footer { get; set; }

        public override string ToString()
        {
            return $"{Head}\n{FileContent}\n{Footer}";
        }
    }
}
