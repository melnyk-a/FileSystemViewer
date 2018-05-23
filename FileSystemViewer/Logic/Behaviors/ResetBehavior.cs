using FileSystemViewer.Engine.Components.Behaviors;
using FileSystemViewer.Engine.Input;
using FileSystemViewer.Logic.Managers.CreatedEntriesList;
using FileSystemViewer.Logic.Managers.Refreshes;

namespace FileSystemViewer.Logic.Behaviors
{
    internal sealed class ResetBehavior : IResetBehavior
    {
        private readonly ICreatedEntriesManager createdEntries;
        private readonly IPressedKeysManager pressedKeys;
        private readonly IRefreshManager updateManager;

        public ResetBehavior(
            ICreatedEntriesManager createdEntries,
            IPressedKeysManager pressedKeys,
            IRefreshManager updateManager
        )
        {
            this.createdEntries = createdEntries;
            this.pressedKeys = pressedKeys;
            this.updateManager = updateManager;
        }

        public bool IsEnabled => updateManager.CanRefresh;

        public void Reset()
        {
            createdEntries.Items.Clear();
            pressedKeys.PressedKeys.Clear();
            updateManager.CanRefresh = false;
        }
    }
}