using FilySystemViewer.Logic.Managers.Entries;
using FilySystemViewer.Logic.Managers.Refreshes;
using FilySystemViewer.Logic.Managers.Sizes;
using FilySystemViewer.Logic.Objects;
using System;

namespace FilySystemViewer.Logic.Behaviors.UpdateBehaviors.UpdatePositionBehavior
{
    internal sealed class UpdateAllPositionsBehavior : UpdatePositionBehavior
    {
        private readonly ISystemRootProvider rootProvider;
        private readonly ISizeProvider sizeProvider;

        public UpdateAllPositionsBehavior(
            ISystemRootProvider rootProvider, 
            ISizeProvider sizeProvider, 
            ISelectedProvider selectedProvider, 
            IRefreshProvider refreshProvider
        ): 
            base(selectedProvider, refreshProvider)
        {
            this.rootProvider = rootProvider;
            this.sizeProvider = sizeProvider;
        }

        private void Move(Func<Point, Point> Offset)
        {
            var iterator = rootProvider.Root.GetForwardIterator();

            while (iterator.HasNext)
            {
                iterator.Next();
                iterator.Current.Position = Offset(iterator.Current.Position);
            }
        }

        private Point OffsetDown(Point point)
        {
            int currnetPosition = point.Y;
            return new Point(point.X, ++currnetPosition);
        }

        private Point OffsetUp(Point point)
        {
            int currnetPosition = point.Y;
            return new Point(point.X, --currnetPosition);
        }

        public override void Update()
        {
            if (selectedProvider.Item.Position.Y == sizeProvider.ScreenLimit.LowerBound + 1)
            {
                var iterator = selectedProvider.Item.GetForwardIterator();

                if (iterator.HasNext)
                {
                    Move(OffsetUp);
                }
            }

            if (selectedProvider.Item.Position.Y == sizeProvider.ScreenLimit.UpperBound - 1)
            {
                var iterator = selectedProvider.Item.GetReverseIterator();

                if (iterator.HasNext)
                {
                    Move(OffsetDown);
                }
            }
        } 
    }
}