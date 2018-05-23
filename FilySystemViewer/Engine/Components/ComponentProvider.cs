using System.Collections.Generic;

namespace FilySystemViewer.Engine.Components
{
    internal sealed class ComponentProvider : IComponentProvider
    {
        private readonly IEnumerable<Component> components;

        public ComponentProvider(IEnumerable<IComponentFinder> componentFinders)
        {
            var components = new List<Component>();

            foreach (IComponentFinder componentFinder in componentFinders)
            {
                components.AddRange(componentFinder.Components);
            }

            this.components = components;
        }

        public IEnumerable<Component> Components => components;
    }
}