using FilySystemViewer.Graphics;
using FilySystemViewer.Logic.Behaviors.DrawBehaviours;
using FilySystemViewer.Logic.Iterators;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Managers.Sizes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;

namespace FilySystemViewer.Logic.Behaviors.DrawBehaviors.DrawEntryBehaviors
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