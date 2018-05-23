using FilySystemViewer.Logic.Managers.CreatedEntriesList;
using FilySystemViewer.Logic.Objects.FileSystemEntries;
using System.Collections.Generic;

namespace FilySystemViewer.Logic
{
    internal sealed class CreatedEntries :
        ICreatedEntriesManager,
        ICreatedEntriesProvider
    {
        public ICollection<FileSystemEntry> Items { get; set; }
            = new List<FileSystemEntry>();
    }
}