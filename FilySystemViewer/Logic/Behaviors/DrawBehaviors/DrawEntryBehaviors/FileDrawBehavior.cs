using FilySystemViewer.Graphics;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Managers.Sizes;
using FilySystemViewer.Logic.Objects;
using FilySystemViewer.Logic.Objects.FileSystemEntries;

namespace FilySystemViewer.Logic.Behaviors.DrawBehaviors.DrawEntryBehaviors
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