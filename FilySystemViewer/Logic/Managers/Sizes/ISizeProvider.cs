using FilySystemViewer.Logic.Objects;

namespace FilySystemViewer.Logic.Managers.Sizes
{
    internal interface ISizeProvider
    {
        ScreenLimit ScreenLimit { get; }
    }
}