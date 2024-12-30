using PrototypeAssembler.Shared.Assembly.FilePreparator;
using System.Text;

namespace PrototypeAssembler.Shared.Assembly
{
    internal class DefaultAssembler : IAssembler
    {
        public DefaultAssembler(AssemblyData data, IFilePreparator filePreparator)
        {
            _data = data;
            _filePreparator = filePreparator;

            DirectoryInfo dirrInfo = new(data.WorkPath);
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
                string content;

                using (StreamReader reader = file.OpenText())
                {
                    content = reader.ReadToEnd();
                }

                preparedFiles.Add(_filePreparator.PrepareFile(new DefaultFile(content, file.Name)));
            }

            StringBuilder stringBuilder = new StringBuilder();

            foreach (PreparedFile preparedFile in preparedFiles)
                stringBuilder.AppendLine(preparedFile.ToString());


            return new(stringBuilder.ToString(), _data.OutputFileName);
        }
    }
}
