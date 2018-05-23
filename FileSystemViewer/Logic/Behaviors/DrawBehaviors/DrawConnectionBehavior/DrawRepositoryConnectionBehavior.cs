using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Managers.Sizes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;
using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;
using System.Linq;
using System.Text;

namespace FileSystemViewer.Logic.Behaviors.DrawBehaviors.DrawConnectionBehavior
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