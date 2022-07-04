

// A local space shape with pivot 0,0
namespace Hex.UN.Runtime.SubSystem.Grid.Hex
{
    public struct HexShape
    {
        public SHexCoordinate[] Hexes { get; private set; }
        public HexShape(SHexCoordinate[] hexes) => this.Hexes = hexes;
    }
}
