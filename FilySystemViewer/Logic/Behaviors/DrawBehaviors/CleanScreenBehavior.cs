using FilySystemViewer.Engine.Components.Behaviors;
using FilySystemViewer.Graphics;
using FilySystemViewer.Logic.Managers.Refreshes;

namespace FilySystemViewer.Logic.Behaviors.DrawBehaviors
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