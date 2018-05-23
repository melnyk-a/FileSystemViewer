﻿using FilySystemViewer.Engine.Input;
using FilySystemViewer.Logic.Iterators;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;

namespace FilySystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors
{
    internal abstract class MoveSelectedBehavior : MoveBehavior
    {
        public MoveSelectedBehavior(
            ISelectedManager selectedManager,
            IPressedKeysProvider pressedKeys,
            IRefreshProvider refreshProvider) :
            base(selectedManager, pressedKeys, refreshProvider)
        {
        }

        protected override void ProcessMove(ISelectedManager selectedManager)
        {
            var iterator = GetIterator(selectedManager.Item);
            iterator.Next();
            if (iterator.HasNext)
            {
                selectedManager.Item.IsSelected = false;
                iterator.Next();
                iterator.Current.IsSelected = true;
                selectedManager.Item = iterator.Current;
            }
        }

        protected abstract IIterator<FileSystemEntry> GetIterator(FileSystemEntry entry);
    }
}