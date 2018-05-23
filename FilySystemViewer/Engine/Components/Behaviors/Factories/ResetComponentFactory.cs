using FilySystemViewer.Engine.Components.Behaviors.Adapters;

namespace FilySystemViewer.Engine.Components.Behaviors.Factories
{
    internal sealed class ResetComponentFactory : IComponentFactory<IResetBehavior>
    {
        public Component CreateComponent(IResetBehavior behavior)
        {
            return new Component(
                 new ResetBehaviorAdapter(behavior),
                 Layers.Reset
            );
        }
    }
}