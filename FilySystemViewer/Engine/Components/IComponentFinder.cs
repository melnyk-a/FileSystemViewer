using System.Collections.Generic;

namespace FilySystemViewer.Engine.Components
{
    internal interface IComponentFinder
    {
        IEnumerable<Component> Components { get; }
    }
}