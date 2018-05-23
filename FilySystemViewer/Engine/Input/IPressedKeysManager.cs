using System.Collections.Generic;

namespace FilySystemViewer.Engine.Input
{
    internal interface IPressedKeysManager
    {
        ICollection<Key> PressedKeys { get; }
    }
}