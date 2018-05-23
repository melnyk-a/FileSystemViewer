using FileSystemViewer.Engine.Exceptions;
using System;

namespace FileSystemViewer.Graphics
{
    internal sealed class ConsoleRenderer : IRenderer
    {
        public int WindowHeight => Console.WindowHeight;
        public int WindowWidth => Console.WindowWidth;

        public void Clear()
        {
            Console.Clear();
        }

        public void Draw(char value)
        {
            Console.Write(value);
        }

        public void Draw(int value)
        {
            Console.Write(value);
        }

        public void Draw(string value)
        {
            Console.Write(value);
        }

        public void DrawEmptyLine()
        {
            Console.WriteLine();
        }

        private ConsoleColor GetConsoleColor(Color color)
        {
            string name = color.ToString();
            bool isDefined = Enum.TryParse(name, out ConsoleColor consoleColor);
            if (!isDefined)
            {
                throw new ColorNotDefinedException(name);
            }
            return consoleColor;
        }

        public void ResetColor()
        {
            Console.ResetColor();
        }

        public void SetBackgroundColor(Color color)
        {
            Console.BackgroundColor = GetConsoleColor(color);
        }

        public void SetForegroundColor(Color color)
        {
            Console.ForegroundColor = GetConsoleColor(color);
        }

        public void SetPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public void SetUpWindow()
        {
            Console.CursorVisible = false;
        }
    }
}