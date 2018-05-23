using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Objects;

namespace FileSystemViewer.Logic.Behaviors.UpdateBehaviors.UpdatePositionBehavior
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