using FileSystemViewer.Logic.Objects.FileSystemEntries;
using System.Collections.Generic;

namespace FileSystemViewer.Logic.Managers.CreatedEntriesList
{
    internal interface ICreatedEntriesManager
    {
        ICollection<FileSystemEntry> Items { get; set; }
    }
}