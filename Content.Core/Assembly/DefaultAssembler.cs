using Content.Core.Assembly.FilePreparator;
using System.Text;

namespace Content.Core.Assembly
{
    internal class BaseAssembler : IAssembler
    {
        public BaseAssembler(AssemblyData data, IFilePreparator filePreparator)
        {
            _data = data;
            _filePreparator = filePreparator;

            DirectoryInfo dirrInfo = new(data.WorkFolderPath);
            _filesForAssembling = dirrInfo.GetFiles()
                .Where(
                    file => file.Name.EndsWith(".yml", StringComparison.OrdinalIgnoreCase) ||
                    file.Name.EndsWith(".yaml", StringComparison.OrdinalIgnoreCase)
                ).ToList();
        }

        private readonly AssemblyData _data;
        private IFilePreparator _filePreparator;

        private List<FileInfo> _filesForAssembling;


        public AssembledFile AssembleFiles()
        {
            List<PreparedFile> preparedFiles = [];

            foreach (FileInfo file in _filesForAssembling)
            {
                string fileContent;

                using (StreamReader reader = file.OpenText())
                {
                    fileContent = reader.ReadToEnd();
                }

                preparedFiles.Add(_filePreparator.PrepareFile(new BaseFile(fileContent)));
            }

            StringBuilder stringBuilder = new();

            // combining files
            foreach (PreparedFile preparedFile in preparedFiles)
                stringBuilder.AppendLine(preparedFile.ToString());

            return new AssembledFile(stringBuilder.ToString());
        }
    }
}

