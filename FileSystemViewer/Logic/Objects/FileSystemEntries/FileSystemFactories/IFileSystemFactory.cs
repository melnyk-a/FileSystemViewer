namespace FileSystemViewer.Logic.Objects.FileSystemEntries.FileSystemFactories
{
    internal interface IFileSystemFactory<T>
    {
        T CreateFile(string path, T parent);
        T CreateFolder(string path, T parent);
        T CreateLogicalDrive(string path, T parent);
        T CreatePC(string path, T parent);
    }
}