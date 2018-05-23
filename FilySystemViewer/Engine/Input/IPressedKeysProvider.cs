namespace FilySystemViewer.Engine.Input
{
    internal interface IPressedKeysProvider
    {
        bool IsPressed(Key key);
    }
}