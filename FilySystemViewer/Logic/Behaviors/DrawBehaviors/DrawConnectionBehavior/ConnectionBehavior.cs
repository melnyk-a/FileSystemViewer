using FilySystemViewer.Graphics;
using FilySystemViewer.Logic.Behaviors.DrawBehaviours;
using FilySystemViewer.Logic.Iterators;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Managers.Sizes;
using FilySystemViewer.Logic.Objects.FileSystemEntries;
using System;

namespace FilySystemViewer.Logic.Behaviors.DrawBehaviors.DrawConnectionBehavior
{
    internal abstract class ConnectionBehavior : DrawBehavior
    {
        protected static char verticalLine = Convert.ToChar(0x2500);
        protected static char horizontallLine = Convert.ToChar(0x2502);
        protected static char terminateLine = Convert.ToChar(0x2514);
        protected static char intermediateLine = Convert.ToChar(0x251C);
        protected static char emptyLine = ' ';

        public ConnectionBehavior(
            ISystemRootProvider rootProvider,
            ISizeProvider sizeProvider,
            IRefreshProvider refreshProvider
        ) :
            base(rootProvider, sizeProvider, refreshProvider)
        {
        }

        protected override Color Background => SystemColors.DefaultBackground;
        protected override Color Foreground => SystemColors.DefaultForeground;

        protected override void DrawItem(IRenderer renderer, IIterator<FileSystemEntry> iterator)
        {
            renderer.SetForegroundColor(Foreground);
            renderer.SetBackgroundColor(Background);
            renderer.SetPosition(0, iterator.Current.Position.Y);
            renderer.Draw(GetConnectionLine(iterator.Current));
        }

        protected char[] FillBuffer(char rest, char last)
        {
            char[] buffer = new char[indent];

            for (int i = 0; i < buffer.Length; ++i)
            {
                buffer[i] = (i == buffer.Length - 1) ? last : rest;
            }

            return buffer;
        }

        protected abstract string GetConnectionLine(FileSystemEntry entry);

        protected bool HasNextSiblingFolder(FileSystemEntry entry)
        {
            bool hasNextSibling = false;
            FileSystemEntry parenent = entry.Parent;
            if (parenent != null)
            {
                int index = parenent.GetRepository().Entries.IndexOf(entry);
                int entriesCount = parenent.GetRepository().Entries.Count;
                
                if (index + 1 < entriesCount && 
                    parenent.GetRepository().Entries[index + 1].GetRepository() != null)
                {
                    hasNextSibling = true;
                }
            }
            return hasNextSibling;
        }
    }
}