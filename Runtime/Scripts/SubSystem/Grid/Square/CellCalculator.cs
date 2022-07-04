using System.Collections;
using System.Collections.Generic;
using HexCS.Core;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

/// <summary>
/// Does calculations to get from coordinates to world space
/// </summary>
public class CellCalculator
{
    private Vector2 _size;
    private Vector2 _origin;

    public CellCalculator(Vector2 size, Vector2 origin)
    {
        _size = size;
        _origin = origin;
    }

    public Vector3 GetWorldPosition(DiscreteVector2 coorindate)
    {
        return _origin + new Vector2(coorindate.X * _size.x, coorindate.Y * _size.y);
    }
}
