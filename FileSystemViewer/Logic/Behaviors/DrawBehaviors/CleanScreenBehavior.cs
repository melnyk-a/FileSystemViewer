using FileSystemViewer.Engine.Components.Behaviors;
using FileSystemViewer.Graphics;
using FileSystemViewer.Logic.Managers.Refreshes;

namespace FileSystemViewer.Logic.Behaviors.DrawBehaviors
{
    internal sealed class CleanScreenBehavior : IDrawBehavior
    {
        private readonly IRefreshManager updateManager;

        public CleanScreenBehavior(IRefreshManager updateManager)
        {
            this.updateManager = updateManager;
        }

        public bool IsEnabled => updateManager.CanRefresh;

        public void Draw(IRenderer renderer)
        {
            renderer.Clear();
        }
    }
}