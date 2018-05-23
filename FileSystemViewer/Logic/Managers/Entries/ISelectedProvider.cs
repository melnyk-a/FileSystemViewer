using FileSystemViewer.Logic.Objects.FileSystemEntries;

namespace FileSystemViewer.Logic.Managers.Entries
{
    internal interface ISelectedProvider
    {
        FileSystemEntry Item { get; }
    }
}