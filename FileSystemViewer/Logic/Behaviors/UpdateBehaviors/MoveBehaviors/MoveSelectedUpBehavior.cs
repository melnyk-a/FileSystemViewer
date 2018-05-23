using FileSystemViewer.Engine.Input;
using FileSystemViewer.Logic.Iterators;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;

namespace FileSystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors
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