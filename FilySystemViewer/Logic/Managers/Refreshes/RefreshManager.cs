namespace FilySystemViewer.Logic.Managers.Refreshes
{
    internal sealed class RefreshManager : IRefreshProvider, IRefreshManager
    {
        public bool CanRefresh { get; set; } = true;
    }
}