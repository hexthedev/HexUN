using HexCS.Core;

namespace Hex.UN.Runtime.SubSystem.Grid.Square
{
    public class Grid<T>
    {
        public Cell<T>[,] Cells;
        public DiscreteVector2 Size => Cells.Size();
        public T this[int x, int y] => Cells[x, y].Data;

        public T this[DiscreteVector2 coord]
        {
            get=> Cells.At(coord).Data;
            set => Cells.At(coord).Data = value;
        } 

        public Grid() : this(new DiscreteVector2()) { }

        public Grid(DiscreteVector2 size)
        {
            CreateGridOfSize(size);
        }

        public void Resize(DiscreteVector2 size)
        {
            if (size == DiscreteVector2.Zero)
            {
                Cells = new Cell<T>[0, 0];
                return;
            }

            Cell<T>[,] oldGrid = Cells;
            CreateGridOfSize(size);
            oldGrid.CopyWhatFits(Cells);
        }


        private void CreateGridOfSize(DiscreteVector2 size)
        {
            Cells = new Cell<T>[size.X, size.Y];
            
            for (int x = 0; x < Cells.GetLength(0); x++)
            {
                for (int y = 0; y < Cells.GetLength(1); y++)
                {
                    Cells[x, y] = new Cell<T>(new DiscreteVector2(x, y), default);
                }
            }

            for (int x = 0; x < Cells.GetLength(0); x++)
            {
                for (int y = 0; y < Cells.GetLength(1); y++)
                    TryAddAllNeighbours((x, y));
            }

            void TryAddAllNeighbours(DiscreteVector2 target)
            {
                foreach (EDirection8Connected direction in UTEnum.GetEnumAsArray<EDirection8Connected>())
                    TryAddNeighbour(target, direction);
            }

            void TryAddNeighbour(DiscreteVector2 target, EDirection8Connected direction)
            {
                DiscreteVector2 child = target + direction.GetStep();

                if (Cells.IsValidIndex(child))
                    Cells.At(target).Neighbours[direction.NeighbourIndex()] = Cells.At(child);
            }
        }
    }
}