using PrototypeAssembler.Shared.Assembly;

namespace PrototypeAssembler.Shared.Saver
{
    internal interface IFileSaver
    {
        public void Save(DefaultFile file);

        public Exception? TrySave(DefaultFile file);

        public bool TrySave(DefaultFile file, out Exception? exception);
    }
}
