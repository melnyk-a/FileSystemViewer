using FilySystemViewer.Engine.Input;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FilySystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors
{
    internal sealed class MoveLeftBehavior : MoveBehavior
    {
        public MoveLeftBehavior(
            ISelectedManager selectedManager,
            IPressedKeysProvider pressedKeys,
            IRefreshProvider refreshProvider
        ) :
            base(selectedManager, pressedKeys, refreshProvider)
        {
        }

        protected override Key Key => Key.LeftArrow;

        protected override void ProcessMove(ISelectedManager selectedManager)
        {
            Repository repository = selectedManager.Item.GetRepository();
            if (repository != null)
            {
                repository.IsExpand = false;
            }
        }
    }
}