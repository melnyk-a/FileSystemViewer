using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Managers.Sizes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;
using FilySystemViewer.Logic.Objects.FileSystemEntries.Repositories;
using System.Linq;
using System.Text;

namespace FilySystemViewer.Logic.Behaviors.DrawBehaviors.DrawConnectionBehavior
{
    internal sealed class DrawRepositoryConnectionBehavior : ConnectionBehavior
    {
        public DrawRepositoryConnectionBehavior(
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

            if (HasNextSiblingFolder(entry))
            {
                builder.Append(FillBuffer(verticalLine, intermediateLine));
            }
            else if (entry.Parent != null)
            {
                builder.Append(FillBuffer(verticalLine, terminateLine));
            }

            FileSystemEntry parentRepository = entry.Parent;
            while (parentRepository != null)
            {
                if (HasNextSiblingFolder(parentRepository))
                {
                    builder.Append(FillBuffer(emptyLine, horizontallLine));
                }
                else if (parentRepository.Parent != null)
                {
                    builder.Append(FillBuffer(emptyLine, emptyLine));
                }
                parentRepository = parentRepository.Parent;
            }

            return new string(builder.ToString().Reverse().ToArray());
        }

        protected override bool NeedToDraw(FileSystemEntry entry)
        {
            return entry is Repository;
        }
    }
}