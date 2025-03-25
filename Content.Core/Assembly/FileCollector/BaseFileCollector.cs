namespace Content.Core.Assembly.FileCollector;
internal class BaseFileCollector : IFileCollector
{
    public BaseFile[] CollectFiles(string path)
    {
        List<FileInfo> _fileInfos = [];
        List<BaseFile> _files = [];

        DirectoryInfo dirrInfo = new(path);
        DirectoryInfo[] directories = { dirrInfo };

        foreach (DirectoryInfo dirr in directories)
        {
            _fileInfos.AddRange(dirr.GetFiles()
                .Where(
                    file => file.Name.EndsWith(".yml", StringComparison.OrdinalIgnoreCase) ||
                    file.Name.EndsWith(".yaml", StringComparison.OrdinalIgnoreCase)
                ).ToList());
        }

        foreach (FileInfo file in _fileInfos)
        {
            string fileContent;
            using (StreamReader reader = file.OpenText())
            {
                fileContent = reader.ReadToEnd();
            }

            _files.Add(new(fileContent, file.FullName, file.Name));
        }

        return _files.ToArray();
    }
}
