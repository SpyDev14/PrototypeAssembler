namespace Content.Core.Assembly.FilePreparator
{
    internal interface IFilePreparator
    {
        public PreparedFile PrepareFile(BaseFile file);
    }
}
