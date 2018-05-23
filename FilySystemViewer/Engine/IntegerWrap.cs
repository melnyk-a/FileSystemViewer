namespace FilySystemViewer.Engine
{
    internal abstract class IntegerWrap
    {
        private readonly int value;

        public IntegerWrap(int value)
        {
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as IntegerWrap);
        }

        public bool Equals(IntegerWrap other)
        {
            return !(other is null) && value.Equals(other.value);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}