using Content.Core.Assembly;
using Content.Core.Assembly.FilePreparator;
using Content.Core.Assembly.FileCollector;
using Content.Core.Saver;

namespace Content.Core;

public class Program
{
    private const string wrongArgumentsErrorMessage
=@"At least 3 arguments are needed!
    arg[0] - workFolderPath*
    arg[1] - assembledFileSavePath*
    arg[2] - assembledFileName*
    arg[3] - (optional) OnFileExistOperation: int or string = 1 (CreateWithIndex)
        ├─ 0 - Overwrite
        ├─ 1 - CreateWithIndex
        └─ 2 - ThrowException
    arg[4] - (optional) author = null";

    static void Main(string[] args)
    {
        /*
            arg[0] - workFolderPath
            arg[1] - assembledFileSavePath
            arg[2] - assembledFileName
            arg[3] - OnFileExistOperation: int or string (optional)
            arg[4] - author (optional)
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
                try {
                    onFileAlreadyExist = Enum.Parse<OnFileAlreadyExist>(args[3]); }

                catch {
                    WriteError("Unknow on file already exsist operation!");
                    throw new ArgumentException("this OnFileExistOperation not exsist");
                }

                if (args.Length >= 5)
                {
                    author = args[4];
                }
            }
        }
        else
        {   
            WriteError(wrongArgumentsErrorMessage);

            throw new ArgumentException("At least 3 arguments are needed");
        }

        Console.WriteLine($"Work folder path:     {workFolderPath}");
        Console.WriteLine($"Assembled file path:  {assembledFileSavePath}");
        Console.WriteLine($"Assembled file name:  {assembledFileName}");
        Console.WriteLine($"On file already exst: {onFileAlreadyExist}");
        Console.WriteLine($"Author:               {author}");
        Console.WriteLine();

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

    private static void WriteError(string msg, bool addErrorPrefix = true, string endsWith = "\n")
    {
        const string errorPrefix = "ERROR:";
        ConsoleColor beforeColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;

        Console.Write($"{(addErrorPrefix? errorPrefix : null)} {msg}{endsWith}");

        Console.ForegroundColor = beforeColor;
    }
}