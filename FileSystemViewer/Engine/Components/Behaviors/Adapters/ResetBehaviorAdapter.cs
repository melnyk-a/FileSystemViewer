namespace FileSystemViewer.Engine.Components.Behaviors.Adapters
{
    internal sealed class ResetBehaviorAdapter : IUpdateBehavior
    {
        private readonly IResetBehavior behavior;

        public ResetBehaviorAdapter(IResetBehavior behavior)
        {
            this.behavior = behavior;
        }

        public bool IsEnabled => behavior.IsEnabled;

        public void Update()
        {
            behavior.Reset();
        }
    }
}