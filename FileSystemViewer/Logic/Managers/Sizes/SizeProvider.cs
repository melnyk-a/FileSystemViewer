using FileSystemViewer.Graphics;
using FileSystemViewer.Logic.Objects;

namespace FileSystemViewer.Logic.Managers.Sizes
{
    internal sealed class SizeProvider : ISizeProvider
    {
        public SizeProvider(IRenderer renderer)
        {
            ScreenLimit = new ScreenLimit(renderer.WindowHeight, 0);
        }

        public ScreenLimit ScreenLimit { get; }
    }
}