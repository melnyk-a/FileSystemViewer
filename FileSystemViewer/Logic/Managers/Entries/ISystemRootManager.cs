using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FileSystemViewer.Logic.Managers.Entries
{
    internal interface ISystemRootManager
    {
        Repository Root { get; set; }
    }
}