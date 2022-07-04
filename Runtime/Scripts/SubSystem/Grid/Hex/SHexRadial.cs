using System;

namespace Hex.UN.Runtime.SubSystem.Grid.Hex
{
    /// <summary>
    /// A hex radial is a structure that stores data using a flat index conversion from SHexCoordinate
    /// based on the assumption that the space is created from rings emitting outwards from an origin,
    /// and enough rings exists to contain all needed coordinates. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SHexRadial<T>
    {
        private int _rings;
    
        public T[] values;

        public SHexRadial(int startingRings = 0)
        {
            _rings = startingRings;
            values = new T[UTHexRadial.TotalHexesInRadial(startingRings)];
        }

        public SHexRadial(SHexCoordinate[] validHexes, Func<SHexCoordinate, T> validHexValueFactory = null)
        {
            int ringRadius = 0;

            foreach (SHexCoordinate hex in validHexes)
            {
                int hexRingRadius = UTHexRadial.RingRadius(hex);
                if (hexRingRadius > ringRadius)
                    ringRadius = hexRingRadius;
            }

            _rings = ringRadius;
            values = new T[UTHexRadial.TotalHexesInRadial(ringRadius)];

            if(validHexValueFactory == null)
                return;
        
            foreach (SHexCoordinate hex in validHexes)
            {
                values[hex.RadialIndex()] = validHexValueFactory(hex);
            }
        }

        public T this[SHexCoordinate index]
        {
            get
            {
                if (!Contains(index))
                    return default;

                return values[ index.RadialIndex() ];
            }
            set
            {
                if (!Contains(index))
                {
                    int requiredRings = UTHexRadial.RingRadius(index);
                    T[] newSpace = new T[UTHexRadial.TotalHexesInRadial(requiredRings)];
                    Array.Copy(values, newSpace, values.Length);
                    values = newSpace;
                    _rings = requiredRings;
                }

                values[index.RadialIndex()] = value;
            }
        }
    
        public bool Contains(SHexCoordinate coord)
        {
            return SHexCoordinate.Distance(SHexCoordinate.Zero, coord) <= _rings;
        }

        public int NonDefaultValueCount()
        {
            int count = 0;
            ForEachNonNull((c, v) => count++);
            return count;
        }

        public void Clear()
        {
            for (int i = 0; i < values.Length; i++)
                values[i] = default;
        }

        public void ForEach(Action<SHexCoordinate, T> action)
        {
            for (int i = 0; i < values.Length; i++)
                action(UTHexRadial.HexFromIndex(i), values[i]);
        }
    
        public void ForEachNonNull(Action<SHexCoordinate, T> action)
        {
            ForEach((h, t) =>
            {
                if (t != null)
                    action(h, t);
            });
        }
    
    }
}