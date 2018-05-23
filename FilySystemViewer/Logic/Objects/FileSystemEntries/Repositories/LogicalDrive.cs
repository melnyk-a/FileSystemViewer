namespace FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories
{
    internal sealed class LogicalDrive : Repository
    {
        public LogicalDrive(string path, FileSystemEntry parent) : 
            base(path, parent)
        {
            Name = path;
        }

        public override Repository GetRepository()
        {
            return this;
        }
    }
}