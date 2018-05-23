using FileSystemViewer.Logic.Objects.FileSystemEntries;
using System.Collections.Generic;

namespace FileSystemViewer.Logic.Managers.CreatedEntriesList
{
    internal interface ICreatedEntriesProvider
    {
        ICollection<FileSystemEntry> Items { get; }
    }
}