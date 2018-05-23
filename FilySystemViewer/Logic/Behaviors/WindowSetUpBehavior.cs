using FilySystemViewer.Engine.Components.Behaviors;
using FilySystemViewer.Graphics;

namespace FilySystemViewer.Logic.Behaviors
{
    internal sealed class WindowSetUpBehavior : ISettingsAdjustmentBehavior
    {
        private readonly IRenderer renderer;

        public WindowSetUpBehavior(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public bool IsEnabled { get; set; } = true;

        public void SetUp()
        {
            renderer.SetUpWindow();
            IsEnabled = false;
        }
    }
}