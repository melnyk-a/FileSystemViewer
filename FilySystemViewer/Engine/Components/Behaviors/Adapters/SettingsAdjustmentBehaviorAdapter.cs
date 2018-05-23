namespace FilySystemViewer.Engine.Components.Behaviors.Adapters
{
    internal sealed class SettingsAdjustmentBehaviorAdapter : IUpdateBehavior
    {
        private readonly ISettingsAdjustmentBehavior behavior;

        public SettingsAdjustmentBehaviorAdapter(
            ISettingsAdjustmentBehavior behavior
        )
        {
            this.behavior = behavior;
        }

        public bool IsEnabled => behavior.IsEnabled;

        public void Update()
        {
            behavior.SetUp();
        }
    }
}