using System.Collections.Generic;

namespace FilySystemViewer.Engine.Input
{
    internal sealed class PressedKeysManager : IPressedKeysProvider, IPressedKeysManager
    {
        private readonly ICollection<Key> pressedKeys = new List<Key>();

        public ICollection<Key> PressedKeys => pressedKeys;

        public bool IsPressed(Key key)
        {
            return PressedKeys.Contains(key);
        }
    }
}