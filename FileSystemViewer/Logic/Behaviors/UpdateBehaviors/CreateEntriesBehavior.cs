using FileSystemViewer.Logic.Managers.CreatedEntriesList;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;
using FileSystemViewer.Logic.Objects.FileSystemEntries.FileSystemFactories;
using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemViewer.Logic.Behaviors.UpdateBehaviors
{
    using CreateEntry = Func<string, FileSystemEntry, FileSystemEntry>;
    internal sealed class CreateEntriesBehavior : UpdateBehavior
    {
        private readonly ICreatedEntriesManager createdManager;
        private readonly IFileSystemFactory<FileSystemEntry> factory;
        private readonly ISelectedProvider selectedProvider;

        public CreateEntriesBehavior(
            IFileSystemFactory<FileSystemEntry> factory,
            ISelectedProvider selectedProvider,
            ICreatedEntriesManager createdManager,
            IRefreshProvider refreshProvider
        ) :
            base(refreshProvider)
        {
            this.selectedProvider = selectedProvider;
            this.createdManager = createdManager;
            this.factory = factory;
        }

        private void AddEntries(IEnumerable<FileSystemEntry> children)
        {
            foreach (var child in children)
            {
                createdManager.Items.Add(child);
            }
        }

        private void AddSubItem(IEnumerable<FileSystemEntry> children)
        {
            if (children != null)
            {
                AddEntries(children);
            }
        }

        private IEnumerable<FileSystemEntry> GetChildren(
            FileSystemEntry parent,
            CreateEntry creator,
            Func<string, string[]> getInner = null
        )
        {
            ICollection<FileSystemEntry> children = null;

            string[] innerEntries = getInner == null ? TryGetInnerEntries() : TryGetInnerEntries(parent.Path, getInner);
            if (innerEntries != null)
            {
                children = new List<FileSystemEntry>();
                for (int i = 0; i < innerEntries.Length; ++i)
                {
                    children.Add(creator(innerEntries[i], parent));
                }
            }

            return children;
        }

        private string[] TryGetInnerEntries(
            string path = null,
            Func<string, string[]> getInner = null
        )
        {
            string[] result = null;
            try
            {
                result = path == null ? Directory.GetLogicalDrives() : getInner(path);
            }
            catch (UnauthorizedAccessException)
            {
            }
            return result;
        }

        public override void Update()
        {
            Repository repository = selectedProvider.Item.GetRepository();
            if (repository != null)
            {
                if (repository.IsExpand && repository.Entries.Count == 0)
                {
                    Repository parent = selectedProvider.Item.GetRepository();

                    if (parent is PC)
                    {
                        AddSubItem(GetChildren(parent, factory.CreateLogicalDrive));
                    }
                    else
                    {
                        AddSubItem(GetChildren(parent, factory.CreateFolder, Directory.GetDirectories));
                        AddSubItem(GetChildren(parent, factory.CreateFile, Directory.GetFiles));
                    }
                }
            }
        }
    }
}