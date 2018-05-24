namespace FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories
{
    internal sealed class PC : Repository
    {
        public PC(string path, FileSystemEntry parent) : 
            base(path, parent)
        {
            Name = PCName;
        }

        private string PCName => NativeMethods.GetComputerFolderName();

        public override Repository Repository => this;
    }
}