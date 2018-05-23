namespace FileSystemViewer.Engine
{
    internal static class Layers
    {
        public static Layer Start { get; } = new Layer(1);
        public static Layer Input { get; } = new Layer(2);
        public static Layer Update { get; } = new Layer(3);
        public static Layer Draw { get; } = new Layer(4);
        public static Layer Reset { get; } = new Layer(5);
    }
}