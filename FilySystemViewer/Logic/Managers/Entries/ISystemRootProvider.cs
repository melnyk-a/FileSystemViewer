using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FilySystemViewer.Logic.Managers.Entries
{
    internal interface ISystemRootProvider
    {
        Repository Root { get; }
    }
}