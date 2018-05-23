using FilySystemViewer.Engine;

namespace FilySystemViewer.Graphics
{
    internal sealed class Color : IntegerWrap
    {
        private readonly string name;

        public Color(int value, string name) : 
            base(value)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}