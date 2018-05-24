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

        public override Repository Repository => null;

        public long Size => new FileInfo(Path).Length;
    }
}