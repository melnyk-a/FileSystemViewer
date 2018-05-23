namespace FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories
{
    internal sealed class Folder : Repository
    {
        public Folder(string path, FileSystemEntry parent) : 
            base(path, parent)
        {
            Name = System.IO.Path.GetFileName(Path);
        }

        public override Repository GetRepository()
        {
            return this;
        }
    }
}