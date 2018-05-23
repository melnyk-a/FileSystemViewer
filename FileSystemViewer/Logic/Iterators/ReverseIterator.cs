using FileSystemViewer.Logic.Objects.FileSystemEntries;
using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;
using System.Collections.Generic;

namespace FileSystemViewer.Logic.Iterators
{
    internal sealed class ReverseIterator : FileSystemIterator
    {
        public ReverseIterator(FileSystemEntry entry) : 
            base(entry)
        {
        }

        protected override IEnumerable<NextItem> CreateSearchFunctions()
        {
            return new NextItem[] { NextChild, NextSibling, NextRelativeDegree };
        }

        private bool HasSibling()
        {
            bool hasSibling = false;

            if (Current.Parent != null)
            {
                Repository parentRepository = Current.Parent.GetRepository();
                if (parentRepository.Entries.Count > 1)
                {
                    hasSibling = true;
                }
            }

            return hasSibling;
        }

        private bool HasRelativeDegree()
        {
            bool hasRelativeDegree = false;

            if (Current.Parent != null)
            {
                hasRelativeDegree = true;
            }

            return hasRelativeDegree;
        }

        private FileSystemEntry NextChild(FileSystemEntry entry)
        {
            FileSystemEntry nextChild = null;

            FileSystemEntry sibling = NextSibling(entry);
            if (sibling != null)
            {
                Repository repository = sibling.GetRepository();
                while (repository != null && repository.IsExpand)
                {
                    nextChild = repository.Entries[repository.Entries.Count - 1];
                    repository = nextChild.GetRepository();
                }
            }

            return nextChild;
        }
        private FileSystemEntry NextRelativeDegree(FileSystemEntry entry)
        {
            FileSystemEntry nextRelativeDegree = null;

            if (HasRelativeDegree())
            {
                nextRelativeDegree = entry.Parent;
            }

            return nextRelativeDegree;
        }

        private FileSystemEntry NextSibling(FileSystemEntry entry)
        {
            FileSystemEntry nextSibling = null;

            if (HasSibling())
            {
                Repository parentRepository = entry.Parent.GetRepository();
                int index = parentRepository.Entries.IndexOf(Current);
                if (index > 0)
                {
                    nextSibling = parentRepository.Entries[index - 1];
                }
            }

            return nextSibling;
        }
    }
}