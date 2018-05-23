namespace FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories
{
    internal sealed class PC : Repository
    {
        public PC(string path, FileSystemEntry parent) : 
            base(path, parent)
        {
            Name = GetPCName();
        }

        private string GetPCName()
        {
            return NativeMethods.GetComputerFolderName();
        }

        public override Repository GetRepository()
        {
            return this;
        }
    }
}