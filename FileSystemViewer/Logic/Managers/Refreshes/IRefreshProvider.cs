namespace FileSystemViewer.Logic.Managers.Refreshes
{
    internal interface IRefreshProvider
    {
        bool CanRefresh { get; }
    }
}