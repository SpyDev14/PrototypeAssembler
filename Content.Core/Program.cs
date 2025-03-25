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
        else
        {   
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"At least 3 arguments are needed!
    arg[0] - workFolderPath
    arg[1] - assembledFileSavePath
    arg[2] - assembledFileName
    arg[3] - (optional) author = null
    arg[4] - (optional) OnFileExistOperation: int or string = 1 (CreateWithIndex)
        ├─ 0 - Overwrite
        ├─ 1 - CreateWithIndex
        └─ 2 - ThrowException");
            
            Console.ResetColor();

            throw new ArgumentException("At least 3 arguments are needed");
        }

        Console.WriteLine($"Work folder path:               {workFolderPath}");
        Console.WriteLine($"Assembled file path:            {assembledFileSavePath}");
        Console.WriteLine($"Assembled file name:            {assembledFileName}");
        Console.WriteLine($"Author:                         {author}");
        Console.WriteLine($"On file already exst operation: {onFileAlreadyExist}\n");

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