using System.Collections.Generic;

namespace FilySystemViewer.Engine.Components
{
    internal interface IComponentProvider
    {
        IEnumerable<Component> Components { get; }
    }
}