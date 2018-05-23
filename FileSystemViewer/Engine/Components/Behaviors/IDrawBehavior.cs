using FileSystemViewer.Graphics;

namespace FileSystemViewer.Engine.Components.Behaviors
{
    internal interface IDrawBehavior : IBehavior
    {
        void Draw(IRenderer renderer);
    }
}