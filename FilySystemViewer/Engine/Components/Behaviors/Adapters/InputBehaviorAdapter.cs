using FilySystemViewer.Engine.Input;

namespace FilySystemViewer.Engine.Components.Behaviors.Adapters
{
    internal sealed class InputBehaviorAdapter : IUpdateBehavior
    {
        private readonly IInputBehavior behavior;
        private readonly IPressedKeysManager manager;

        public InputBehaviorAdapter(
            IInputBehavior behavior, 
            IPressedKeysManager manager
        )
        {
            this.behavior = behavior;
            this.manager = manager;
        }

        public bool IsEnabled => behavior.IsEnabled;

        public void Update()
        {
            behavior.ProcessInput(manager);
        }
    }
}