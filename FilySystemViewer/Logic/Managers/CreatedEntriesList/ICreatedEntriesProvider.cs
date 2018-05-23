using FilySystemViewer.Logic.Objects.FileSystemEntries;
using System.Collections.Generic;

namespace FilySystemViewer.Logic.Managers.CreatedEntriesList
{
    internal interface ICreatedEntriesProvider
    {
        ICollection<FileSystemEntry> Items { get; }
    }
}