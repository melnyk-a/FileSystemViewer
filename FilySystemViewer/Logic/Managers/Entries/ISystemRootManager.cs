using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FilySystemViewer.Logic.Managers.Entries
{
    internal interface ISystemRootManager
    {
        Repository Root { get; set; }
    }
}