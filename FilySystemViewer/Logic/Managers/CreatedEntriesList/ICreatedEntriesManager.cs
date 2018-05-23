using FilySystemViewer.Logic.Objects.FileSystemEntries;
using System.Collections.Generic;

namespace FilySystemViewer.Logic.Managers.CreatedEntriesList
{
    internal interface ICreatedEntriesManager
    {
        ICollection<FileSystemEntry> Items { get; set; }
    }
}