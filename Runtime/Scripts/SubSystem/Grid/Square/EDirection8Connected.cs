using HexCS.Core;

namespace Hex.UN.Runtime.SubSystem.Grid.Square
{
    public enum EDirection8Connected
    {
        Up, 
        UpRight,
        Right,
        DownRight,
        Down,
        DownLeft,
        Left,
        UpLeft,
    }

    public static class UTEDirection8Connected
    {
        public static DiscreteVector2 GetStep(this EDirection8Connected target)
        {
            switch (target)
            {
                case EDirection8Connected.Up:
                    return new DiscreteVector2(0, 1);
                case EDirection8Connected.UpRight:
                    return new DiscreteVector2(1, 1);
                case EDirection8Connected.Right:
                    return new DiscreteVector2(1, 0);
                case EDirection8Connected.DownRight:
                    return new DiscreteVector2(1, -1);
                case EDirection8Connected.Down:
                    return new DiscreteVector2(0, -1);
                case EDirection8Connected.DownLeft:
                    return new DiscreteVector2(-1, -1);
                case EDirection8Connected.Left:
                    return new DiscreteVector2(-1, 0);
                case EDirection8Connected.UpLeft:
                    return new DiscreteVector2(-1, 1);
            }

            return default;
        }
    }
}