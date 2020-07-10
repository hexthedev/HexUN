using System;
using System.Collections.Generic;

namespace HexUN.CSStandard
{
    /// <summary>
    /// Property bags allow for generic data to stored with some key
    /// and expose functions for attempting to retrieve that data
    /// </summary>
    public class PropertyBag<TKey>
    {
        /// <summary>
        /// Used to store the generic data
        /// </summary>
        protected Dictionary<TKey, object> _bag = new Dictionary<TKey, object>();

        /// <summary>
        /// Get keys as enumerable
        /// </summary>
        public IEnumerable<TKey> Keys => _bag.Keys;

        /// <summary>
        /// Does the bag contain an object with the key
        /// </summary>
        /// <param name="key"></param>
        public bool Contains(TKey key) => _bag.ContainsKey(key);

        /// <summary>
        /// Remove the object at key
        /// </summary>
        /// <param name="key"></param>
        public void Remove(TKey key) => _bag.Remove(key);

        /// <summary>
        /// Attempt to put an object in the bag. Will return false 
        /// if key already exists, and will not overwrite the last value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Put(TKey key, object data)
        {
            if (_bag.ContainsKey(key)) return false;
            
            _bag[key] = data;
            return true;
        }

        /// <summary>
        /// Put an object in the bag. will overwite any previous data
        /// </summary>
        /// <param name="key"></param>
        public void PutOrReplace(TKey key, object data) => _bag[key] = data;

        /// <summary>
        /// If the bag contains the key returns the object stored at that key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(TKey key, out object value) => _bag.TryGetValue(key, out value);

        /// <summary>
        /// If the bag contains the key, and the object at that key is of 
        /// type T, returns the value. Otherwise retusn false.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue<T>(TKey key, out T value)
        {
            bool result = TryGetValue(key, out object o);

            if (!result)
            {
                value = default;
                return false;
            }

            try
            {
                value = (T)o;
            }
            catch (InvalidCastException)
            {
                value = default;
                return false;
            }

            return true;
        }
    }
}