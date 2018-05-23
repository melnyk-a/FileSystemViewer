using FileSystemViewer.Engine.Input;

namespace FileSystemViewer.Engine.Components.Behaviors
{
    internal interface IInputBehavior : IBehavior
    {
        void ProcessInput(IPressedKeysManager manager);
    }
}