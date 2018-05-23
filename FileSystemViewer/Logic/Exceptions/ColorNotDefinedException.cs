using System;

namespace FileSystemViewer.Engine.Exceptions
{
    internal sealed class ColorNotDefinedException : Exception
    {
        private readonly string color;

        public ColorNotDefinedException(string color)
        {
            this.color = color;
        }
        public override string Message
        {
            get
            {
                return $"Color \"{color}\" is not defined " +
                       $"in enumerator ConsoleColor";
            }
        }
    }
}