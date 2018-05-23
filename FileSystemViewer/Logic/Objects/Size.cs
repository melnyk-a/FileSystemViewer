namespace FileSystemViewer.Logic.Objects
{
    internal sealed class ScreenLimit
    {
        private readonly int lowerBound;
        private readonly int upperBound;

        public ScreenLimit(int lowerBound, int upperBound)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
        }

        // -1 для корректной работы с индексами.
        public int LowerBound => lowerBound - 1;
        public int UpperBound => upperBound;
    }
}