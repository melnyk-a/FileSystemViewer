namespace FileSystemViewer.Engine.Frames
{
    internal interface IFrameRunner : IRunnable
    {
        int RunOrder { get; }
    }
}