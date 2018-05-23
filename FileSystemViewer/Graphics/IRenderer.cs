namespace FileSystemViewer.Graphics
{
    internal interface IRenderer
    {
        int WindowHeight { get; }
        int WindowWidth { get; }

        void Clear();
        void Draw(char value);
        void Draw(int value);
        void Draw(string value);
        void DrawEmptyLine();
        void ResetColor();
        void SetForegroundColor(Color color);
        void SetBackgroundColor(Color color);
        void SetPosition(int x, int y);
        void SetUpWindow();
    }
}