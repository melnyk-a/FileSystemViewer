using FileSystemViewer.Logic.Objects;

namespace FileSystemViewer.Logic.Managers.Sizes
{
    internal interface ISizeProvider
    {
        ScreenLimit ScreenLimit { get; }
    }
}