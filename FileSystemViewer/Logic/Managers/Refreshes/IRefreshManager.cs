namespace FileSystemViewer.Logic.Managers.Refreshes
{
    internal interface IRefreshManager
    {
        bool CanRefresh { get; set; }
    }
}