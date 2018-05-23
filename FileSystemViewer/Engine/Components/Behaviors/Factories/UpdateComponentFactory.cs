namespace FileSystemViewer.Engine.Components.Behaviors.Factories
{
    internal sealed class UpdateComponentFactory : IComponentFactory<IUpdateBehavior>
    {
        public Component CreateComponent(IUpdateBehavior behavior)
        {
            return new Component(behavior, Layers.Update);
        }
    }
}