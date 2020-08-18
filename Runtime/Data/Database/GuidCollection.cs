using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HexUN.Data
{
    public interface IGuidCollection
    {
        /// <summary>
        /// All guids
        /// </summary>
        Guid[] Guids { get; }

        /// <summary>
        /// Add guids with default values
        /// </summary>
        /// <param name="guids"></param>
        void AddGuidRange(params Guid[] guids);
    }

    public interface IGuidCollection<T> : IGuidCollection
    {
        /// <summary>
        /// All elements
        /// </summary>
        T[] Values { get; }

        /// <summary>
        /// Add or create a guid item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        void AddOrCreate(Guid id, T item);

        /// <summary>
        /// Iterate over all stored guids and populate with items found in map
        /// </summary>
        /// <param name="map"></param>
        void Populate(Dictionary<Guid, T> map);

        /// <summary>
        /// Returns item at removed guid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T RemoveByGuid(Guid id);

        /// <summary>
        /// Returns guid at removed item
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Guid RemoveByValue(T value);
    }


    /// <summary>
    /// Datastructure used to identify object references with a Guid, then resolve those references later
    /// </summary>
    public class GuidCollection<T> : IGuidCollection<T>
    {
        // TO DO: Foreach compatibility
        private Dictionary<Guid, T> _items = new Dictionary<Guid, T>();

        /// <inheritdoc/>
        public T[] Values => _items.Values.ToArray();

        /// <inheritdoc/>
        public Guid[] Guids => _items.Keys.ToArray();

        /// <inheritdoc/>
        public void AddGuidRange(params Guid[] guids)
        {
            foreach (Guid id in guids) _items.Add(id, default);
        }

        /// <inheritdoc/>
        public void AddOrCreate(Guid id, T item)
        {
            _items[id] = item;
        }

        /// <inheritdoc/>
        public void Populate(Dictionary<Guid, T> map)
        {
            List<(Guid, T)> tuples = new List<(Guid, T)>();

            foreach(Guid g in _items.Keys)
            {
                if(map.TryGetValue(g, out T val))
                {
                    tuples.Add((g, val));
                }
            }

            foreach((Guid, T) t in tuples)
            {
                _items[t.Item1] = t.Item2;
            }
        }

        /// <inheritdoc/>
        public T RemoveByGuid(Guid id)
        {
            T val = _items[id];
            _items.Remove(id);
            return val;
        }

        /// <inheritdoc/>
        public Guid RemoveByValue(T value)
        {
            Guid id = default;

            foreach(KeyValuePair<Guid, T> kv in _items)
            {
                if (kv.Value.Equals(value)) id = kv.Key; 
            }

            _items.Remove(id);
            return id;
        }
    }
}