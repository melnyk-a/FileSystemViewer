using FileSystemViewer.Engine.Input;
using FileSystemViewer.Logic.Iterators;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;

namespace FileSystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors
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