using Content.Core.Assembly;

namespace Content.Core.Saver
{
    internal interface IFileSaver
    {
        public void Save(DefaultFile file);

        public Exception? TrySave(DefaultFile file);

        public bool TrySave(DefaultFile file, out Exception? exception);
    }
}
