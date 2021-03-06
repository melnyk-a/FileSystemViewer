﻿using FileSystemViewer.Engine.Components;

namespace FileSystemViewer.Engine.Frames
{
    internal sealed class InputFrameRunner : FrameRunner
    {
        public InputFrameRunner(IComponentProvider componentProvider) :
            base(componentProvider)
        {
        }

        protected override Layer Layer => Layers.Input;

        public override int RunOrder => RunOrders.Input;
    }
}