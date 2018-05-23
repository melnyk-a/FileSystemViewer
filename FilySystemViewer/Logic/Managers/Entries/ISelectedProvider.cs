using FilySystemViewer.Logic.Objects.FileSystemEntries;

namespace FilySystemViewer.Logic.Managers.Entries
{
    internal interface ISelectedProvider
    {
        FileSystemEntry Item { get; }
    }
}