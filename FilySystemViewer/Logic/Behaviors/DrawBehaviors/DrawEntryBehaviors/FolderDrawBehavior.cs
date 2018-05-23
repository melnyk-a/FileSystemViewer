using FilySystemViewer.Graphics;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Managers.Sizes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;
using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FilySystemViewer.Logic.Behaviors.DrawBehaviors.DrawEntryBehaviors
{
    internal sealed class FolderDrawBehavior : RepositoryDrawBehavior
    {
        public FolderDrawBehavior(
            ISystemRootProvider rootProvider,
            ISizeProvider sizeProvider,
            IRefreshProvider refreshProvider
        ) :
            base(rootProvider, sizeProvider, refreshProvider)
        {
        }

        protected override Color Foreground => SystemColors.Folder;

        protected override bool NeedToDraw(FileSystemEntry entry)
        {
            return entry is Folder;
        }
    }
}