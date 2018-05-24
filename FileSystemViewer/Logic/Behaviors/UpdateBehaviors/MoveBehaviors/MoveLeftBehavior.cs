using FileSystemViewer.Engine.Input;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FileSystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors
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
            Repository repository = selectedManager.Item.Repository;
            if (repository != null)
            {
                repository.IsExpand = false;
            }
        }
    }
}