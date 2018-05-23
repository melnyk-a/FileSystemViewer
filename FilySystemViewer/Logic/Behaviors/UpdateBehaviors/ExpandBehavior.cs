using FilySystemViewer.Logic.Behaviors.UpdateBehaviors;
using FilySystemViewer.Logic.Managers.CreatedEntriesList;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;
using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FilySystemViewer.Logic.Behaviors.UpdateBehaviours
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
            Repository repository = selectedProvider.Item.GetRepository();
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