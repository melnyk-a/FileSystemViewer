using FilySystemViewer.Engine.Input;
using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;

namespace FilySystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors
{
    internal abstract class MoveBehavior : UpdateBehavior
    {
        private readonly ISelectedManager selectedManager;
        private readonly IPressedKeysProvider pressedKeys;

        public MoveBehavior(
            ISelectedManager selectedManager,
            IPressedKeysProvider pressedKeys,
            IRefreshProvider refreshProvider
        ) :
            base(refreshProvider)
        {
            this.selectedManager = selectedManager;
            this.pressedKeys = pressedKeys;
        }

        protected abstract Key Key { get; }

        protected abstract void ProcessMove(ISelectedManager selectedManager);

        public override void Update()
        {
            if (pressedKeys.IsPressed(Key))
            {
                ProcessMove(selectedManager);
            }
        }
    }
}