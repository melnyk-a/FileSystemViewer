using FilySystemViewer.Engine.Components.Behaviors;
using FilySystemViewer.Engine.Input;
using FilySystemViewer.Logic.Managers.CreatedEntriesList;
using FilySystemViewer.Logic.Managers.Refreshes;

namespace FilySystemViewer.Logic.Behaviors
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