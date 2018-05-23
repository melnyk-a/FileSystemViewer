using FilySystemViewer.Graphics;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Managers.Sizes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;
using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FilySystemViewer.Logic.Behaviors.DrawBehaviors.DrawEntryBehaviors
{
    internal sealed class PCDrawBehavior : RepositoryDrawBehavior
    {
        public PCDrawBehavior(
            ISystemRootProvider rootProvider,
            ISizeProvider sizeProvider,
            IRefreshProvider refreshProvider
        ) :
            base(rootProvider, sizeProvider, refreshProvider)
        {
        }

        protected override Color Foreground => SystemColors.PC;

        protected override bool NeedToDraw(FileSystemEntry entry)
        {
            return entry is PC;
        }
    }
}