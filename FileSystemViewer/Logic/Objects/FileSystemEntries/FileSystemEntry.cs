using FileSystemViewer.Logic.Iterators;
using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FileSystemViewer.Logic.Objects.FileSystemEntries
{
    internal abstract class FileSystemEntry
    {
        public FileSystemEntry(string path, FileSystemEntry parent)
        {
            Path = path;
            Parent = parent;
            Position = new Point(GenerationCount, 0);
        }

        public int GenerationCount
        {
            get
            {
                int count = 0;

                FileSystemEntry parent = Parent;
                while (parent != null)
                {
                    ++count;
                    parent = parent.Parent;
                }

                return count;
            }
        }

        public bool IsSelected { get; set; }

        public virtual string Name { get; protected set; }

        public FileSystemEntry Parent { get; private set; }

        public string Path { get; private set; }

        public Point Position { get; set; }

        public abstract Repository Repository { get; }

        public IIterator<FileSystemEntry> GetForwardIterator()
        {
            return new ForwardIterator(this);
        }

        public IIterator<FileSystemEntry> GetReverseIterator()
        {
            return new ReverseIterator(this);
        }
    }
}