using FilySystemViewer.Engine.Components.Behaviors.Adapters;

namespace FilySystemViewer.Engine.Components.Behaviors.Factories
{
    internal sealed class SettingsAdjustmentFactory : IComponentFactory<ISettingsAdjustmentBehavior>
    {
        public Component CreateComponent(ISettingsAdjustmentBehavior behavior)
        {
            return new Component(
                new SettingsAdjustmentBehaviorAdapter(behavior),
                Layers.Start
            );
        }
    }
}