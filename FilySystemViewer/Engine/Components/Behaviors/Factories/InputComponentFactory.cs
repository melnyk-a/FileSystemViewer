using FilySystemViewer.Engine.Components.Behaviors.Adapters;
using FilySystemViewer.Engine.Input;

namespace FilySystemViewer.Engine.Components.Behaviors.Factories
{
    internal sealed class InputComponentFactory : IComponentFactory<IInputBehavior>
    {
        private readonly IPressedKeysManager keyManager;

        public InputComponentFactory(IPressedKeysManager keyManager)
        {
            this.keyManager = keyManager;
        }

        public Component CreateComponent(IInputBehavior behavior)
        {
            return new Component(
                new InputBehaviorAdapter(behavior, keyManager),
                Layers.Input
            );
        }
    }
}