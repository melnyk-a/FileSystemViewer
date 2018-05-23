using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FileSystemViewer.Logic.Managers.Entries
{
    internal interface ISystemRootProvider
    {
        Repository Root { get; }
    }
}