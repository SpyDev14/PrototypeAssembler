namespace Content.Core.Saver;
internal class BaseSaver(SaveData data) : IFileSaver
{
    private readonly SaveData _data = data;

    public void Save(BaseFile file)
    {
        string fullPath = _data.OutputPath + $"\\{_data.AssembledFileName}.yml";

        int index = 1;
        while (File.Exists(fullPath))
        {
            switch (_data.OnFileAlreadyExistOperation)
            {
                case OnFileAlreadyExist.Overwrite:
                    File.Delete(fullPath);
                    break;

                case OnFileAlreadyExist.CreateWithIndex:
                    fullPath = _data.OutputPath + $"\\{_data.AssembledFileName} ({index}).yml";
                    index++;
                    break;

                case OnFileAlreadyExist.ThrowException:
                    throw new FileAlreadyExistsException($"File {_data.AssembledFileName}.yml in {_data.OutputPath} already exist");
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