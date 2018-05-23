using FileSystemViewer.Engine.Components;

namespace FileSystemViewer.Engine.Frames
{
    internal sealed class UpdateFrameRunner : FrameRunner
    {
        public UpdateFrameRunner(IComponentProvider componentProvider) :
            base(componentProvider)
        {
        }

        protected override Layer Layer => Layers.Update;
        public override int RunOrder => RunOrders.Update;
    }
}