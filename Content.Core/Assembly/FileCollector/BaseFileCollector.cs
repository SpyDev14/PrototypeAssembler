using System.IO;

namespace Content.Core.Assembly.FileCollector;
internal class BaseFileCollector : IFileCollector
{
    private const int _maxFileSize = 2097152; // 2mb
    private const string _maxFileKbSizeString = "2048"; //{Math.Round((double)_maxFileSize/1024, 1)}

    public BaseFile[] CollectFiles(string workDirrectoryPath)
    {
        List<FileInfo> files     = [];
        List<BaseFile> baseFiles = [];
        Dictionary<FileInfo, string> ignoredFiles = []; //File / Reason

        Console.WriteLine("Files for assembling:");
        foreach (var filePath in Directory.EnumerateFiles(workDirrectoryPath, "*.yml", SearchOption.AllDirectories))
        {
            FileInfo file = new(filePath);
            long fileSize = file.Length;

            if (fileSize > _maxFileSize)
            {
                ignoredFiles.Add(file, $"The file has exceeded the maximum allowed size of {_maxFileKbSizeString}kb ({Math.Round((double)fileSize/1024, 1)}kb)");
                continue;
            }
            
            Console.WriteLine($" -> {filePath} ({Math.Round((double)fileSize/1024, 1)}kb)");
            files.Add(file);
        }

        if (ignoredFiles.Count > 0)
        {
            Console.WriteLine("\nIGNORED FILES:");

            foreach (var keyValuePair in ignoredFiles)
            {
                FileInfo file = keyValuePair.Key;

                Console.WriteLine($" -> File:    {file.FullName}");
                Console.WriteLine($"    Reason:  {keyValuePair.Value}");
            }
        }

        foreach (var file in files)
        {
            string fileContent = default!;
            using (StreamReader reader = file.OpenText())
            {
                fileContent = reader.ReadToEnd();
            }

            baseFiles.Add (
                new BaseFile(
                    fileContent,
                    file.FullName.Substring(0, file.FullName.Length - file.Name.Length),
                    file.Name
                ) {
                    FileInfo = file
                }
            );
        }

        return baseFiles.ToArray();
    }
}
