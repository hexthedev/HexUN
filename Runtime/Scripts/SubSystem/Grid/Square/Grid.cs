using System;
using System.Collections.Generic;
using HexCS.Core;

namespace Hex.UN.Runtime.SubSystem.Grid.Square
{
    /// <summary>
    /// Grids follow [col, row] coordinates
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Grid<T>
        where T: new()
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
     
        public IEnumerable<Cell<T>> EnumerateLine(DiscreteVector2 start, DiscreteVector2 step)
        {
            if (step.X == 0 && step.Y == 0)
                yield return Cells.At(start);

            DiscreteVector2 cur = start;

            int lengthX = Cells.GetLength(0);
            int lengthY = Cells.GetLength(1);

            while (cur.X >= 0 && cur.X < lengthX && cur.Y >= 0 && cur.Y < lengthY)
            {
                yield return Cells[cur.X, cur.Y];
                cur += step;
            }
        }

        private void CreateGridOfSize(DiscreteVector2 size)
        {
            Cells = new Cell<T>[size.X, size.Y];
            
            for (int col = 0; col < Cells.GetLength(0); col++)
            {
                for (int row = 0; row < Cells.GetLength(1); row++)
                {
                    Cells[col, row] = new Cell<T>(new DiscreteVector2(col, row), new T());
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