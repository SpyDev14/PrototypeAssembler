using Content.Core.Assembly;
using Content.Core.Assembly.FilePreparator;
using Content.Core.Saver;

namespace Content.Core
{
    public class Program
    {
        static void Main(string[] args)
        {
            string folderPath = "C:\\Users\\Admin\\Desktop\\debug folder";
            string outputPath = "C:\\Users\\Admin\\Desktop\\debug out folder";
            string author = "Spy";
            string assembledFileName = "Test";

            AssemblyData assemblyData = new(folderPath, assembledFileName)
            {
                Author = author,
                AdAuthor = true
            };
            SaveData saveData = new(outputPath);

            IAssembler assembler = new DefaultAssembler(assemblyData, new DefaultFilePreparator(assemblyData));

            AssembledFile assembledFile = assembler.AssembleFiles();

            IFileSaver saver = new BaseSaver(saveData);
            saver.Save(assembledFile);
        }
    }
}