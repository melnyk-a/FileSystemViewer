using FilySystemViewer.Engine.Frames;
using System.Collections.Generic;
using System.Linq;

namespace FilySystemViewer
{
    internal sealed class ApplicationLogic : IRunnable
    {
        private readonly IEnumerable<IFrameRunner> frameRunners;

        public ApplicationLogic(IEnumerable<IFrameRunner> frameRunners)
        {
            this.frameRunners = frameRunners;
        }

        public void Run()
        {
            IEnumerable<IFrameRunner> orderedFrameRunners = frameRunners
                .OrderBy(frameRunner => frameRunner.RunOrder)
                .ToList();

            while (true)
            {
                foreach (IFrameRunner frameRunner in orderedFrameRunners)
                {
                    frameRunner.Run();
                }
            }
        }
    }
}