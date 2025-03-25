namespace Content.Core.Saver;

internal class BaseSaver(SaveData data) : IFileSaver
{
    private readonly SaveData _data = data;

    public void Save(BaseFile file)
    {
        string outputFileName = _data.AssembledFileName;
        const string protoExtension = ".yml";

        if (outputFileName.EndsWith(protoExtension))
            outputFileName = outputFileName.Substring(0, outputFileName.Length - protoExtension.Length);

        string fullPath = _data.OutputPath + $"\\{outputFileName}.yml";

        int index = 1;
        while (File.Exists(fullPath))
        {
            switch (_data.OnFileAlreadyExistOperation)
            {
                case OnFileAlreadyExist.Overwrite:
                    File.Delete(fullPath);
                    Console.WriteLine("\nFile overwrited (i)");
                    break;

                case OnFileAlreadyExist.CreateWithIndex:
                    fullPath = _data.OutputPath + $"\\{outputFileName} ({index}){protoExtension}";
                    index++;
                    break;

                case OnFileAlreadyExist.ThrowException:
                    throw new FileAlreadyExistsException($"File {outputFileName}{protoExtension} in {_data.OutputPath} already exist");
            }
        }

        using (FileStream fileStream = File.Create(fullPath))
        {
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(file.FileContent);
            }
        }
    }

    public bool TrySave(BaseFile file, out Exception? exception)
    {
        try
        {
            Save(file);
        }
        catch (Exception e)
        {
            exception = e;
            return false;
        }

        exception = null;
        return true;
    }
}