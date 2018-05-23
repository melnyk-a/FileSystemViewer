using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FileSystemViewer.Logic.Behaviors.UpdateBehaviors
{
    internal sealed class CollapseBehavior : UpdateBehavior
    {
        private readonly ISelectedProvider selectedProvider;

        public CollapseBehavior(
            ISelectedProvider selectedProvider, 
            IRefreshProvider refreshProvider
        ): 
            base(refreshProvider)
        {
            this.selectedProvider = selectedProvider;
        }

        public override void Update()
        {
            Repository repository = selectedProvider.Item.GetRepository();
            if (repository != null)
            {
                if (!repository.IsExpand && repository.Entries.Count > 0)
                {
                    repository.Entries.Clear();
                }
            }
        }
    }
}