using FilySystemViewer.Engine.Components;

namespace FilySystemViewer.Engine.Frames
{
    internal abstract class FrameRunner : IFrameRunner
    {
        private readonly IComponentProvider componentProvider;

        public FrameRunner(IComponentProvider componentProvider)
        {
            this.componentProvider = componentProvider;
        }

        protected abstract Layer Layer { get; }
        public abstract int RunOrder { get; }

        public virtual void Run()
        {
            foreach (Component component in componentProvider.Components)
            {
                if (component.Layer == Layer)
                {
                    component.Update();
                }
            }
        }
    }
}