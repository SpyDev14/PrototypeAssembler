namespace Content.Core;

internal class BaseFile
{
    public BaseFile(string fileContent) => FileContent = fileContent;
    public BaseFile(string fileContent, string? path) : this(fileContent) => Path = path;
    public BaseFile(string fileContent, string? path, string? name) : this(fileContent, path) => Name = name;

    public string FileContent { get; protected set; }
    public string? Path {get; protected set; }
    public string? Name { get; set; }

    public FileInfo? FileInfo { get; set; }
}