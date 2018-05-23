using System.Collections.Generic;

namespace FileSystemViewer.Engine.Input
{
    internal interface IPressedKeysManager
    {
        ICollection<Key> PressedKeys { get; }
    }
}