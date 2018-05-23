using FileSystemViewer.Logic.Managers.CreatedEntriesList;
using FileSystemViewer.Logic.Objects.FileSystemEntries;
using System.Collections.Generic;

namespace FileSystemViewer.Logic
{
    internal sealed class CreatedEntries :
        ICreatedEntriesManager,
        ICreatedEntriesProvider
    {
        public ICollection<FileSystemEntry> Items { get; set; }
            = new List<FileSystemEntry>();
    }
}