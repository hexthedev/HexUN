using System;
using UnityEngine;

namespace Hex.UN.Runtime.SubSystem.Grid.Hex
{
    public class SHexCoordinateCalculator
    {
        private float size;
        private float width;
        private float height;
        private float verticalSpacing;
        private float horizontalSpacing;
    
        public SHexCoordinateCalculator(float size)
        {
            this.size = size;
            width = (float) Math.Sqrt(3) * size;
            height = 2 * size;
            verticalSpacing = height / 4 * 3;
            horizontalSpacing = width;
        }

        public Vector2 Solve(SHexCoordinate coords)
        {
            return new Vector2(
                (coords.Y - coords.Z) / 2f * horizontalSpacing,
                coords.X * verticalSpacing
            );
        } 
    }
}
