using FilySystemViewer.Engine.Components.Behaviors.Adapters;
using FilySystemViewer.Graphics;

namespace FilySystemViewer.Engine.Components.Behaviors.Factories
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