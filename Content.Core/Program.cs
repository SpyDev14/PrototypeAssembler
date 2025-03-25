using Content.Core.Assembly;
using Content.Core.Assembly.FilePreparator;
using Content.Core.Assembly.FileCollector;
using Content.Core.Saver;

namespace Content.Core;

public class Program
{
    static void Main(string[] args)
    {
        /*
            arg[0] - workFolderPath
            arg[1] - assembledFileSavePath
            arg[2] - assembledFileName
            arg[3] - author (optional)
            arg[4] - OnFileExistOperation: int (optional)
        */

        string workFolderPath, assembledFileSavePath, assembledFileName;
        string? author = null;
        OnFileAlreadyExist onFileAlreadyExist = OnFileAlreadyExist.CreateWithIndex;

        if (args.Length >= 3)
        {
            workFolderPath = args[0];
            assembledFileSavePath = args[1];
            assembledFileName = args[2];

            if (args.Length >= 4)
            {
                author = args[3];

                if (args.Length >= 5)
                {
                    Enum.TryParse(args[4], out onFileAlreadyExist);
                }
            }
        }
        else throw new ArgumentNullException("at least 2 arguments are needed");

        AssemblyData assemblyData = new(workFolderPath)
        {
            Author = author
        };
        SaveData saveData = new(assembledFileSavePath, assembledFileName)
        {
            OnFileAlreadyExistOperation = onFileAlreadyExist
        };

        IAssembler assembler = new BaseAssembler(assemblyData, new BaseFilePreparator(assemblyData), new BaseFileCollector());

        AssembledFile assembledFile = assembler.AssembleFiles();

        IFileSaver saver = new BaseSaver(saveData);
        saver.Save(assembledFile);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nУспешно!");
        Console.ResetColor();
    }
}