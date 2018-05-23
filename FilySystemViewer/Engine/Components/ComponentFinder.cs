using FilySystemViewer.Engine.Components.Behaviors.Factories;
using System.Collections.Generic;

namespace FilySystemViewer.Engine.Components
{
    internal sealed class ComponentFinder<TBehavior> : IComponentFinder
    {
        private readonly IEnumerable<Component> components;

        public ComponentFinder(
            IEnumerable<TBehavior> behaviors,
            IComponentFactory<TBehavior> factory
        )
        {
            var components = new List<Component>();

            foreach (TBehavior behavior in behaviors)
            {
                var component = factory.CreateComponent(behavior);
                components.Add(component);
            }

            this.components = components;
        }

        public IEnumerable<Component> Components => components;
    }
}