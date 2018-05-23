using FileSystemViewer.Logic.Objects.FileSystemEntries;

namespace FileSystemViewer.Logic.Managers.Entries
{
    internal interface ISelectedManager
    {
        FileSystemEntry Item { get; set; }
    }
}