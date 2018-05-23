using FilySystemViewer.Engine.Input;
using FilySystemViewer.Logic.Iterators;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;

namespace FilySystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors
{
    internal sealed class MoveDownBehavior : MoveSelectedBehavior
    {
        public MoveDownBehavior(
            ISelectedManager selectedManager,
            IPressedKeysProvider pressedKeys,
            IRefreshProvider refreshProvider
        ) :
            base(selectedManager, pressedKeys, refreshProvider)
        {
        }

        protected override Key Key => Key.DownArrow;

        protected override IIterator<FileSystemEntry> GetIterator(FileSystemEntry entry)
        {
            return entry.GetForwardIterator();
        }
    }
}