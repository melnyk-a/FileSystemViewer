using FileSystemViewer.Engine.Components.Behaviors;
using FileSystemViewer.Logic.Managers.Refreshes;

namespace FileSystemViewer.Logic.Behaviors.UpdateBehaviors
{
    internal abstract class UpdateBehavior : IUpdateBehavior
    {
        private readonly IRefreshProvider refreshProvider;

        public UpdateBehavior(IRefreshProvider refreshProvider)
        {
            this.refreshProvider = refreshProvider;
        }

        public bool IsEnabled => refreshProvider.CanRefresh;

        public abstract void Update();
    }
}