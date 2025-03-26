namespace Content.Core.Saver;

public class SaveData(string outPath, string assembledFileName)
{
    public string AssembledFileSavePath { get; set; } = outPath;

    public string AssembledFileName {  get; set; } = assembledFileName;

    public OnFileAlreadyExist OnFileAlreadyExistOperation { get; set; }
        = OnFileAlreadyExist.CreateWithIndex;
}

public enum OnFileAlreadyExist
{
    Overwrite,
    CreateWithIndex,
    ThrowException
}