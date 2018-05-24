using FileSystemViewer.Engine.Components.Behaviors;

namespace FileSystemViewer.Engine.Components
{
    internal sealed class Component
    {
        private readonly Layer layer;
        private readonly IUpdateBehavior behavior;

        public Component(IUpdateBehavior behavior, Layer layer)
        {
            this.behavior = behavior;
            this.layer = layer;
        }

        public bool IsEnabled => behavior.IsEnabled;

        public Layer Layer => layer;

        public void Update()
        {
            if (IsEnabled)
            {
                behavior.Update();
            }
        }
    }
}