using FilySystemViewer.Engine.Input;

namespace FilySystemViewer.Engine.Components.Behaviors
{
    internal interface IInputBehavior : IBehavior
    {
        void ProcessInput(IPressedKeysManager manager);
    }
}