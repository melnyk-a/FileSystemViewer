using System.Collections.Generic;

namespace FileSystemViewer.Engine.Components
{
    internal interface IComponentProvider
    {
        IEnumerable<Component> Components { get; }
    }
}