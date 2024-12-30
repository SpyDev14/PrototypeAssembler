namespace PrototypeAssembler.Shared.Assembly
{
    internal class AssemblyData(string workPath, string outputFileName)
    {

        public string WorkPath { get; private set; } = workPath;

        public string OutputFileName {  get; set; } = outputFileName;

        public string? Author { get; set; }
        public bool AdAuthor { get; set; } = false;
    }
}
