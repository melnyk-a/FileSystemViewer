using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Objects;

namespace FilySystemViewer.Logic.Behaviors.UpdateBehaviors.UpdatePositionBehavior
{
    internal sealed class UpdatePositionAfterSelectedBehavior : UpdatePositionBehavior
    {
        public UpdatePositionAfterSelectedBehavior(
            ISelectedProvider selectedProvider,
            IRefreshProvider refreshProvider
        ) :
            base(selectedProvider, refreshProvider)
        {
        }

        public override void Update()
        {
            var iterator = selectedProvider.Item.GetForwardIterator();
            iterator.Next();

            while (iterator.HasNext)
            {
                int updatedYPosition = iterator.Current.Position.Y;
                iterator.Next();
                iterator.Current.Position = new Point(iterator.Current.Position.X, ++updatedYPosition);
            }
        }
    }
}