namespace Content.Core.Assembly.FileCollector
{
    internal interface IFileCollector
    {
        public BaseFile[] CollectFiles(string path);
    }
}
