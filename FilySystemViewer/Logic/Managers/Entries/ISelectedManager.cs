using FilySystemViewer.Logic.Objects.FileSystemEntries;

namespace FilySystemViewer.Logic.Managers.Entries
{
    internal interface ISelectedManager
    {
        FileSystemEntry Item { get; set; }
    }
}