using FilySystemViewer.Logic.Objects.FileSystemEntries;

namespace FilySystemViewer.Logic.Managers.Entries
{
    internal sealed class SelectManager : 
        ISelectedManager, 
        ISelectedProvider
    {
        public FileSystemEntry Item { get; set; }
    }
}