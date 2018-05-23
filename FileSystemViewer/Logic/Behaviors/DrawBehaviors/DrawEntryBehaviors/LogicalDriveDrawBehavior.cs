using FileSystemViewer.Graphics;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Managers.Sizes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;
using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FileSystemViewer.Logic.Behaviors.DrawBehaviors.DrawEntryBehaviors
{
    internal sealed class LogicalDriveDrawBehavior : RepositoryDrawBehavior
    {
        public LogicalDriveDrawBehavior(
            ISystemRootProvider rootProvider,
            ISizeProvider sizeProvider,
            IRefreshProvider refreshProvider
        ) :
            base(rootProvider, sizeProvider, refreshProvider)
        {
        }

        protected override Color Foreground => SystemColors.LogicalDrive;

        protected override bool NeedToDraw(FileSystemEntry entry)
        {
            return entry is LogicalDrive;
        }
    }
}