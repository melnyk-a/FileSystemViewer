using FilySystemViewer.Logic.Iterators;
using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FilySystemViewer.Logic.Objects.FileSystemEntries
{
    internal abstract class FileSystemEntry
    {
        public FileSystemEntry(string path, FileSystemEntry parent)
        {
            Path = path;
            Parent = parent;
            Position = new Point(GetGenerationCount(), 0);
        }

        public bool IsSelected { get; set; }
        public virtual string Name { get; protected set; }
        public FileSystemEntry Parent { get; private set; }
        public string Path { get; private set; }
        public Point Position { get; set; }

        public int GetGenerationCount()
        {
            int count = 0;

            FileSystemEntry parent = this.Parent;
            while (parent != null)
            {
                ++count;
                parent = parent.Parent;
            }

            return count;
        }

        public IIterator<FileSystemEntry> GetForwardIterator()
        {
            return new ForwardIterator(this);
        }

        public abstract Repository GetRepository();

        public IIterator<FileSystemEntry> GetReverseIterator()
        {
            return new ReverseIterator(this);
        }
    }
}