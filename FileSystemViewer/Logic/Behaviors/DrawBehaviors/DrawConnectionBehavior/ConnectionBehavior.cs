﻿using FileSystemViewer.Graphics;
using FileSystemViewer.Logic.Behaviors.DrawBehaviours;
using FileSystemViewer.Logic.Iterators;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Managers.Sizes;
using FileSystemViewer.Logic.Objects.FileSystemEntries;
using System;

namespace FileSystemViewer.Logic.Behaviors.DrawBehaviors.DrawConnectionBehavior
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
                int index = parenent.Repository.Entries.IndexOf(entry);
                int entriesCount = parenent.Repository.Entries.Count;
                
                if (index + 1 < entriesCount && 
                    parenent.Repository.Entries[index + 1].Repository != null)
                {
                    hasNextSibling = true;
                }
            }
            return hasNextSibling;
        }
    }
}