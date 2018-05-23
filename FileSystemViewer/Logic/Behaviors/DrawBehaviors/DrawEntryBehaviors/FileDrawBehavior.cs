using FileSystemViewer.Graphics;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Managers.Sizes;
using FileSystemViewer.Logic.Objects;
using FileSystemViewer.Logic.Objects.FileSystemEntries;

namespace FileSystemViewer.Logic.Behaviors.DrawBehaviors.DrawEntryBehaviors
{
    internal sealed class FileDrawBehavior : DrawEntryBehavior
    {
        public FileDrawBehavior(
            ISystemRootProvider rootProvider,
            ISizeProvider sizeProvider,
            IRefreshProvider refreshProvider
        ) :
            base(rootProvider, sizeProvider, refreshProvider)
        {
        }

        protected override Color Foreground => SystemColors.File;

        protected override string GetName(FileSystemEntry entry)
        {
            string size = Converter.BytesToString(((File)entry).GetSize());
            return $"{entry.Name} ({size})";
        }

        protected override bool NeedToDraw(FileSystemEntry entry)
        {
            return entry is File;
        }
    }
}