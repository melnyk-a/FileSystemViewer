using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Managers.Sizes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;
using System.Linq;
using System.Text;

namespace FilySystemViewer.Logic.Behaviors.DrawBehaviors.DrawConnectionBehavior
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