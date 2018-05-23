using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Managers.Sizes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;

namespace FileSystemViewer.Logic.Behaviors.DrawBehaviors.DrawEntryBehaviors
{
    internal abstract class RepositoryDrawBehavior : DrawEntryBehavior
    {
        public RepositoryDrawBehavior(
            ISystemRootProvider rootProvider,
            ISizeProvider sizeProvider,
            IRefreshProvider refreshProvider
        ) :
            base(rootProvider, sizeProvider, refreshProvider)
        {
        }

        protected override string GetName(FileSystemEntry entry)
        {
            return entry.Name;
        }
    }
}