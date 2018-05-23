using FileSystemViewer.Logic.Objects.FileSystemEntries;

namespace FileSystemViewer.Logic.Managers.Entries
{
    internal sealed class SelectManager : 
        ISelectedManager, 
        ISelectedProvider
    {
        public FileSystemEntry Item { get; set; }
    }
}