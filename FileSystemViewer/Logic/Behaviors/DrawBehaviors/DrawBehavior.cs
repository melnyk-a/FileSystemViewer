using FileSystemViewer.Engine.Components.Behaviors;
using FileSystemViewer.Graphics;
using FileSystemViewer.Logic.Iterators;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Managers.Sizes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;

namespace FileSystemViewer.Logic.Behaviors.DrawBehaviours
{
    internal abstract class DrawBehavior : IDrawBehavior
    {
        protected const int indent = 2;
        private readonly ISystemRootProvider rootProvider;
        private readonly ISizeProvider sizeProvider;
        private readonly IRefreshProvider refreshProvider;

        public DrawBehavior(
            ISystemRootProvider rootProvider,
            ISizeProvider sizeProvider,
            IRefreshProvider refreshProvider
        )
        {
            this.rootProvider = rootProvider;
            this.sizeProvider = sizeProvider;
            this.refreshProvider = refreshProvider;
        }

        protected abstract Color Background { get; }
        protected abstract Color Foreground { get; }
        public bool IsEnabled => refreshProvider.CanRefresh;

        public void Draw(IRenderer renderer)
        {
            var iterator = rootProvider.Root.GetForwardIterator();

            while (iterator.HasNext)
            {
                iterator.Next();
                if (NeedToDraw(iterator.Current))
                {
                    if (IsInLimits(iterator.Current))
                    {
                        DrawItem(renderer, iterator);
                    }
                }
            }
            renderer.ResetColor();
        }

        protected abstract void DrawItem(
            IRenderer render,
            IIterator<FileSystemEntry> iterator
        );

        protected bool IsInLimits(FileSystemEntry entry)
        {
            return entry.Position.Y <= sizeProvider.ScreenLimit.LowerBound &&
                entry.Position.Y >= sizeProvider.ScreenLimit.UpperBound;
        }

        protected abstract bool NeedToDraw(FileSystemEntry entry);
    }
}