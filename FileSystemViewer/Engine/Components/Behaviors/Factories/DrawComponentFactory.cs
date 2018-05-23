using FileSystemViewer.Engine.Components.Behaviors.Adapters;
using FileSystemViewer.Graphics;

namespace FileSystemViewer.Engine.Components.Behaviors.Factories
{
    internal sealed class DrawComponentFactory : IComponentFactory<IDrawBehavior>
    {
        private readonly IRenderer renderer;

        public DrawComponentFactory(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public Component CreateComponent(IDrawBehavior behavior)
        {
            return new Component(
                new DrawBehaviorAdapter(behavior, renderer),
                Layers.Draw
            );
        }
    }
}