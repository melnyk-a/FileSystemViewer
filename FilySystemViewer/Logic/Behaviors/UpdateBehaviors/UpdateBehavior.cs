using FilySystemViewer.Engine.Components.Behaviors;
using FilySystemViewer.Logic.Managers.Refreshes;

namespace FilySystemViewer.Logic.Behaviors.UpdateBehaviors
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