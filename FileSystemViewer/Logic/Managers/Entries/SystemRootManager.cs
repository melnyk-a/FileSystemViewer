using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FileSystemViewer.Logic.Managers.Entries
{
    internal sealed class SystemRootManager :
        ISystemRootProvider,
        ISystemRootManager
    {
        public Repository Root { get; set; }
    }
}