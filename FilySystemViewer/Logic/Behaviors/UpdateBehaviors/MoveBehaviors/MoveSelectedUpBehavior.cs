using FilySystemViewer.Engine.Input;
using FilySystemViewer.Logic.Iterators;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;

namespace FilySystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors
{
    internal sealed class MoveUpBehavior : MoveSelectedBehavior
    {
        public MoveUpBehavior(
            ISelectedManager selectedManager,
            IPressedKeysProvider pressedKeys,
            IRefreshProvider refreshProvider
        ) :
            base(selectedManager, pressedKeys, refreshProvider)
        {
        }

        protected override Key Key => Key.UpArrow;

        protected override IIterator<FileSystemEntry> GetIterator(FileSystemEntry entry)
        {
            return entry.GetReverseIterator();
        }
    }
}