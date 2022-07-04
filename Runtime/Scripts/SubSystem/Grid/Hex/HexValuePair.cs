namespace Hex.UN.Runtime.SubSystem.Grid.Hex
{
    public class HexValuePair<T>
    {
        public SHexCoordinate hex;
        public T Value;

        public HexValuePair(SHexCoordinate hex, T value)
        {
            this.hex = hex;
            Value = value;
        }
    }
}