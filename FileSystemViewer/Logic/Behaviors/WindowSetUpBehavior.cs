using FileSystemViewer.Engine.Components.Behaviors;
using FileSystemViewer.Graphics;

namespace FileSystemViewer.Logic.Behaviors
{
    internal sealed class WindowSetUpBehavior : ISettingsAdjustmentBehavior
    {
        private readonly IRenderer renderer;

        public WindowSetUpBehavior(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public bool IsEnabled { get; private set; } = true;

        public void SetUp()
        {
            renderer.SetUpWindow();
            IsEnabled = false;
        }
    }
}