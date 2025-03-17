using Content.Core.Assembly;

namespace Content.Core.Saver
{
    internal interface IFileSaver
    {
        public void Save(BaseFile file);

        public bool TrySave(BaseFile file, out Exception? exception);
    }
}
