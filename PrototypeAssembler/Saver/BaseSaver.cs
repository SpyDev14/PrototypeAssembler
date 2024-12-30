using System.IO;

namespace PrototypeAssembler.Shared.Saver
{
    internal class BaseSaver(SaveData data) : IFileSaver
    {
        private readonly SaveData _data = data;

        public void Save(DefaultFile file)
        {
            string fullPath = _data.OutputPath + $"\\{file.Name}.yml";

            int index = 1;
            while (File.Exists(fullPath))
            {
                switch (_data.FileAlreadyExistOperation)
                {
                    case OnFileAlreadyExistOperation.Overwrite:
                        Console.Write("Overwrite file? [Y]> ");
                        var answer = Console.ReadLine();

                        if (answer.ToLower() != "y")
                        {
                            Console.WriteLine("Terminating...");
                            Environment.Exit(0);
                        }

                        File.Delete(fullPath);
                        break;

                    case OnFileAlreadyExistOperation.CreateWithIndex:
                        fullPath = _data.OutputPath + $"\\{file.Name}({index}).yml";
                        index++;
                        break;

                    case OnFileAlreadyExistOperation.ThrowEx:
                        throw new FileAlreadyExistsEsception();
                }
            }

            using (FileStream fileStream = File.Create(fullPath))
            {
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(file.Content);
                }
            }
        }

        public Exception? TrySave(DefaultFile file)
        {
            try
            {
                Save(file);

                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public bool TrySave(DefaultFile file, out Exception? exception)
        {
            exception = TrySave(file);

            return exception == null;
        }
    }
}
