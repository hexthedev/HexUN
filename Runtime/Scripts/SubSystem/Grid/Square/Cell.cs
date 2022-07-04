using HexCS.Core;

namespace Hex.UN.Runtime.SubSystem.Grid.Square
{
    public class Cell<TData>
    {
        public DiscreteVector2 Coorindate;
        public Cell<TData>[] Neighbours = new Cell<TData>[8];
        public TData Data;
        
        public Cell(DiscreteVector2 coordinate, TData data)
        {
            Coorindate = coordinate;
            Data = data;
        }

        public void AddNeighbour(EDirection8Connected direction, Cell<TData> cell)
            => Neighbours[direction.NeighbourIndex()] = cell;

        public void RemoveNeighbour(EDirection8Connected direction)
            => Neighbours[direction.NeighbourIndex()] = null;
    }
}