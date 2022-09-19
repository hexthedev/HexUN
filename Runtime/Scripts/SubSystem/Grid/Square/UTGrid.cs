using System;
using System.Collections.Generic;
using HexCS.Core;

namespace Hex.UN.Runtime.SubSystem.Grid.Square
{
    public static class UTGrid
    {
        /// <summary>
        /// Calculates the flat index of a 2DGrid index 
        /// </summary>
        public static int FlatIndex(DiscreteVector2 gridSize, DiscreteVector2 index)
        {
            return index.X + index.Y * gridSize.X;
        }

        /// <summary>
        /// Calculates the index of a 2DGrid from a flat index 
        /// </summary>
        public static DiscreteVector2 UnflatIndex(DiscreteVector2 gridSize, int flatIndex)
        {
            return new DiscreteVector2(flatIndex % gridSize.X, flatIndex / gridSize.X );
        }

        public static int FlatSize(DiscreteVector2 gridSize)
        {
            return gridSize.X * gridSize.Y;
        }
        
        
        public static Cell<T>[] FindFirstSequence<T>(
            this Grid<T> grid,
            StartAndStep[] startAndSteps,
            Predicate<Cell<T>[]> analyzer
        ) where T : new()
        {
            List<Cell<T>> sequence = new List<Cell<T>>();

            foreach (StartAndStep s in startAndSteps)
            {
                sequence.Clear();
                sequence.AddRange(grid.EnumerateLine(s.Origin, s.Step));

                if (analyzer(sequence.ToArray()))
                    return sequence.ToArray();
            }

            return null;
        }
    }
}