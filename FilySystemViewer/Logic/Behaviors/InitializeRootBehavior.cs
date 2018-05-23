using FilySystemViewer.Engine.Components.Behaviors;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Objects.FileSystemEntries;
using FilySystemViewer.Logic.Objects.FileSystemEntries.FileSystemFactories;
using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FilySystemViewer.Logic.Behaviors
{
    internal sealed class InitializeRootBehavior : ISettingsAdjustmentBehavior
    {
        private readonly IFileSystemFactory<FileSystemEntry> factory;
        private readonly ISelectedManager selectedManager;
        private readonly ISystemRootManager systemRoot;

        public InitializeRootBehavior(
            IFileSystemFactory<FileSystemEntry> factory,
            ISelectedManager selectedManager,
            ISystemRootManager systemRoot
        )
        {
            this.selectedManager = selectedManager;
            this.factory = factory;
            this.systemRoot = systemRoot;
        }

        public bool IsEnabled { get; set; } = true;

        public void SetUp()
        {
            systemRoot.Root = factory.CreatePC(null, null) as Repository;
            Repository repository = systemRoot.Root.GetRepository();
            repository.IsExpand = true;
            repository.IsSelected = true;
            selectedManager.Item = systemRoot.Root;
            IsEnabled = false;
        }
    }
}