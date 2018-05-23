using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;

namespace FilySystemViewer.Logic.Behaviors.UpdateBehaviors.UpdatePositionBehavior
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