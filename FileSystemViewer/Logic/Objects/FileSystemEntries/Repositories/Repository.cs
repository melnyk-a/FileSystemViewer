using System.Collections.Generic;

namespace FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories
{
    internal abstract class Repository : FileSystemEntry
    {
        public Repository(string path, FileSystemEntry parent) :
            base(path, parent)
        {
            Name = System.IO.Path.GetFileName(Path);
        }

        public IList<FileSystemEntry> Entries { get; private set; }
            = new List<FileSystemEntry>();
        public bool IsExpand { get; set; }
    }
}