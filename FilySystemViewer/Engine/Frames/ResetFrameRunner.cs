﻿using FilySystemViewer.Engine.Components;

namespace FilySystemViewer.Engine.Frames
{
    internal sealed class ResetFrameRunner : FrameRunner
    {
        public ResetFrameRunner(IComponentProvider componentProvider) :
            base(componentProvider)
        {
        }

        protected override Layer Layer => Layers.Reset;
        public override int RunOrder => RunOrders.Reset;
    }
}