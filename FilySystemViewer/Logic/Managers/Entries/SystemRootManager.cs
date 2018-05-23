using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FilySystemViewer.Logic.Managers.Entries
{
    internal sealed class SystemRootManager :
        ISystemRootProvider,
        ISystemRootManager
    {
        public Repository Root { get; set; }
    }
}