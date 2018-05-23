using System.Collections.Generic;

namespace FileSystemViewer.Engine.Components
{
    internal interface IComponentFinder
    {
        IEnumerable<Component> Components { get; }
    }
}