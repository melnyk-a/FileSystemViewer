namespace FilySystemViewer.Engine.Frames
{
    internal static class RunOrders
    {
        private static int count = 0;

        public static int Start => Next();
        public static int Input => Next();
        public static int Update => Next();
        public static int Draw => Next();
        public static int Reset => Next();

        private static int Next()
        {
            count++;
            return count;
        }
    }
}