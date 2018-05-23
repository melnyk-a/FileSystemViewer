using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;
using System.IO;

namespace FileSystemViewer.Logic.Objects.FileSystemEntries
{
    internal sealed class File : FileSystemEntry
    {
        public File(string path, FileSystemEntry parent) : 
            base(path, parent)
        {
            Name = System.IO.Path.GetFileName(Path);
        }

        public override Repository GetRepository()
        {
            return null;
        }

        public long GetSize()
        {
            return new FileInfo(Path).Length;
        }
    }
}