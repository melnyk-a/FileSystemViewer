using FilySystemViewer.Engine.Input;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FilySystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors
{
    internal sealed class MoveRightBehavior : MoveBehavior
    {
        public MoveRightBehavior(
            ISelectedManager selectedManager, 
            IPressedKeysProvider pressedKeys, 
            IRefreshProvider refreshProvider
        ) :
            base(selectedManager, pressedKeys, refreshProvider)
        {
        }

        protected override Key Key => Key.RightArrow;

        protected override void ProcessMove(ISelectedManager selectedManager)
        {
            Repository repository = selectedManager.Item.GetRepository();
            if (repository != null)
            {
                repository.IsExpand = true;
            }
        }
    }
}