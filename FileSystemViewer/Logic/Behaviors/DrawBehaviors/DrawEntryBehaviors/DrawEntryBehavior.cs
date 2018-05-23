using FileSystemViewer.Graphics;
using FileSystemViewer.Logic.Behaviors.DrawBehaviours;
using FileSystemViewer.Logic.Iterators;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Managers.Sizes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;

namespace FileSystemViewer.Logic.Behaviors.DrawBehaviors.DrawEntryBehaviors
{
    internal abstract class DrawEntryBehavior : DrawBehavior
    {
        public DrawEntryBehavior(
            ISystemRootProvider rootProvider,
            ISizeProvider sizeProvider,
            IRefreshProvider refreshProvider
        ) :
            base(rootProvider, sizeProvider, refreshProvider)
        {
        }

        protected override Color Background => SystemColors.DefaultBackground;

        protected override void DrawItem(IRenderer renderer, IIterator<FileSystemEntry> iterator)
        {
            renderer.SetForegroundColor(Foreground);
            renderer.SetBackgroundColor(Background);

            int x = iterator.Current.Position.X * indent;
            int y = iterator.Current.Position.Y;

            renderer.SetPosition(x, y);

            if (iterator.Current.IsSelected)
            {
                renderer.SetBackgroundColor(SystemColors.Selected);
                renderer.Draw(GetName(iterator.Current));
                renderer.ResetColor();
            }
            else
            {
                renderer.Draw(GetName(iterator.Current));
            }
        }

        protected abstract string GetName(FileSystemEntry entry);
    }
}