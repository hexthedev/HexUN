namespace Hex.UN.Runtime.SubSystem.Grid.Square
{
    public static class UTCell
    {
        public static int NeighbourIndex(this EDirection8Connected direction)
            => (int) direction;
    }
}