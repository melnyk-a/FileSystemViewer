using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FilySystemViewer.Logic.Objects.FileSystemEntries.FileSystemFactories
{
    internal sealed class FileSystemFactory :
        IFileSystemFactory<FileSystemEntry>
    {
        public FileSystemEntry CreateFile(
            string path,
            FileSystemEntry parent
        )
        {
            return new File(path, parent);
        }

        public FileSystemEntry CreateFolder(
            string path,
            FileSystemEntry parent
        )
        {
            return new Folder(path, parent);
        }

        public FileSystemEntry CreateLoficalDrive(
            string path,
            FileSystemEntry parent
        )
        {
            return new LogicalDrive(path, parent);
        }

        public FileSystemEntry CreatePC(
            string path,
            FileSystemEntry parent
        )
        {
            return new PC(path, parent);
        }
    }
}