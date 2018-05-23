using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Managers.Sizes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;
using System.Linq;
using System.Text;

namespace FileSystemViewer.Logic.Behaviors.DrawBehaviors.DrawConnectionBehavior
{
    internal sealed class DrawFileConnectionBehavior : ConnectionBehavior
    {
        public DrawFileConnectionBehavior(
            ISystemRootProvider rootProvider,
            ISizeProvider sizeProvider,
            IRefreshProvider refreshProvider
        ) :
            base(rootProvider, sizeProvider, refreshProvider)
        {
        }

        protected override string GetConnectionLine(FileSystemEntry entry)
        {
            StringBuilder builder = new StringBuilder();

            FileSystemEntry currentRepository = entry;
            while (currentRepository.Parent != null)
            {
                if (HasNextSiblingFolder(currentRepository))
                {
                    builder.Append(FillBuffer(emptyLine, horizontallLine));
                }
                else
                {
                    builder.Append(FillBuffer(emptyLine, emptyLine));
                }
                currentRepository = currentRepository.Parent;
            }

            return new string(builder.ToString().Reverse().ToArray());
        }

        protected override bool NeedToDraw(FileSystemEntry entry)
        {
            return entry is File;
        }
    }
}