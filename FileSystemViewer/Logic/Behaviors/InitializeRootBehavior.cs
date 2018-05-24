using FileSystemViewer.Engine.Components.Behaviors;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Objects.FileSystemEntries;
using FileSystemViewer.Logic.Objects.FileSystemEntries.FileSystemFactories;
using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FileSystemViewer.Logic.Behaviors
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

        public bool IsEnabled { get; private set; } = true;

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