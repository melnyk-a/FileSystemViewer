using FilySystemViewer.Graphics;

namespace FilySystemViewer.Engine.Components.Behaviors.Adapters
{
    internal sealed class DrawBehaviorAdapter : IUpdateBehavior
    {
        private readonly IDrawBehavior behavior;
        private readonly IRenderer renderer;

        public DrawBehaviorAdapter(IDrawBehavior behavior, IRenderer renderer)
        {
            this.behavior = behavior;
            this.renderer = renderer;
        }

        public bool IsEnabled => behavior.IsEnabled;

        public void Update()
        {
            behavior.Draw(renderer);
        }
    }
}