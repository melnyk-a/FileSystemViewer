using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Managers.Sizes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;

namespace FilySystemViewer.Logic.Behaviors.DrawBehaviors.DrawEntryBehaviors
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