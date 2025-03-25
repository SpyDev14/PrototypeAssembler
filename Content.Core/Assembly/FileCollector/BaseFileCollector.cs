using System.IO;

namespace Content.Core.Assembly.FileCollector;
internal class BaseFileCollector : IFileCollector
{
    public BaseFile[] CollectFiles(string workDirrectoryPath)
    {
        List<FileInfo> files     = [];
        List<BaseFile> baseFiles = [];

        Console.WriteLine("Files for assembling:");
        foreach (var filePath in Directory.EnumerateFiles(workDirrectoryPath, "*.yml", SearchOption.AllDirectories))
        {
            Console.WriteLine($" » {filePath}");
            files.Add(new FileInfo(filePath));
        }

        foreach (var file in files)
        {
            string fileContent = default!;
            using (StreamReader reader = file.OpenText())
            {
                fileContent = reader.ReadToEnd();
            }

            baseFiles.Add (
                new (
                    fileContent,
                    $"{file.FullName}\\{file.Name}",
                    file.Name
                ) {
                    FileInfo = file
                }
            );
        }

        return baseFiles.ToArray();
    }
}
