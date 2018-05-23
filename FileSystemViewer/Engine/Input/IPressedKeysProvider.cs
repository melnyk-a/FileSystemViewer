namespace FileSystemViewer.Engine.Input
{
    internal interface IPressedKeysProvider
    {
        bool IsPressed(Key key);
    }
}