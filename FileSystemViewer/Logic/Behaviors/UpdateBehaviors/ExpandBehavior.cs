using FileSystemViewer.Logic.Behaviors.UpdateBehaviors;
using FileSystemViewer.Logic.Managers.CreatedEntriesList;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;
using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FileSystemViewer.Logic.Behaviors.UpdateBehaviours
{
    internal sealed class ExpandBehavior : UpdateBehavior
    {
        private readonly ICreatedEntriesProvider createdEntries;
        private readonly ISelectedProvider selectedProvider;

        public ExpandBehavior(
            ISelectedProvider selectedProvider,
            ICreatedEntriesProvider createdEntries,
            IRefreshProvider refreshProvider
        ) :
            base(refreshProvider)
        {
            this.selectedProvider = selectedProvider;
            this.createdEntries = createdEntries;
        }

        public override void Update()
        {
            Repository repository = selectedProvider.Item.Repository;
            if (repository != null)
            {
                foreach (FileSystemEntry entry in createdEntries.Items)
                {
                    repository.Entries.Add(entry);
                }
                if (repository.Entries.Count == 0)
                {
                    repository.IsExpand = false;
                }
            }
        }
    }
}