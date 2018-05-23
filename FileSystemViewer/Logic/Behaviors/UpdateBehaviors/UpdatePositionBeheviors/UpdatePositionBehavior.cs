using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;

namespace FileSystemViewer.Logic.Behaviors.UpdateBehaviors.UpdatePositionBehavior
{
    internal abstract class UpdatePositionBehavior : UpdateBehavior
    {
        protected readonly ISelectedProvider selectedProvider;

        public UpdatePositionBehavior(
            ISelectedProvider selectedProvider,
            IRefreshProvider refreshProvider
        ) :
            base(refreshProvider)
        {
            this.selectedProvider = selectedProvider;
        }
    }
}