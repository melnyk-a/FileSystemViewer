using FilySystemViewer.Graphics;

namespace FilySystemViewer.Engine.Components.Behaviors
{
    internal interface IDrawBehavior : IBehavior
    {
        void Draw(IRenderer renderer);
    }
}