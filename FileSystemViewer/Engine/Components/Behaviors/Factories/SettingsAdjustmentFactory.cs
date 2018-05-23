using FileSystemViewer.Engine.Components.Behaviors.Adapters;

namespace FileSystemViewer.Engine.Components.Behaviors.Factories
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