namespace FileSystemViewer.Logic.Iterators
{
    internal interface IIterator<T>
    {
        T Current { get; }

        bool HasNext { get; }
        void Next();
    }
}