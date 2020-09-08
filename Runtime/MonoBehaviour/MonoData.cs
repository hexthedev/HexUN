using System.Collections.Generic;
using UnityEngine;
using HexUN.Render;

namespace HexUN.MonoB
{
    /// <summary>
    /// Abstract class for all controls
    /// </summary>
    public abstract class MonoData : MonoEnhanced
    {
        #region Protected API
        [Header("Proto UI Data (APuiControl)")]
        [SerializeField]
        [Tooltip("Generic data used for querying info about UI control")]
        protected List<ScriptableObject> _genericSoData;

        /// <summary>
        /// All pui data. Pui data can be any type. The puiSoData is only used to allow
        /// adding pui data in editor.
        /// </summary>
        protected List<object> _data;

        protected override void MonoAwake()
        {
            base.MonoAwake();

            _data = new List<object>();
            if (_genericSoData != null) _data.AddRange(_genericSoData);
        }
        #endregion

        #region API
        /// <summary>
        /// Generic data used for querying info about UI control
        /// </summary>
        public object[] Data => _data.ToArray();

        /// <summary>
        /// Try get the first listed data of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool TryGetData<T>(out T data)
        {
            foreach (object obj in _data)
            {
                if (obj is T)
                {
                    data = (T)obj;
                    return true;
                }
            }

            data = default;
            return false;
        }

        /// <summary>
        /// Try get all occurences of a data type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public void TryGetAllData<T>(out List<T> data)
        {
            data = new List<T>();

            foreach (object obj in _data)
            {
                if (obj is T)
                {
                    data.Add((T)obj);
                }
            }
        }

        /// <summary>
        /// Add a pui data to the data
        /// </summary>
        /// <param name="data"></param>
        public void AddData(object data)
        {
            if (_data == null) _data = new List<object>();
            _data.Add(data);
        }

        /// <summary>
        /// Remove a pui data from data
        /// </summary>
        /// <param name="data"></param>
        public void RemoveData(object data) => _data?.Remove(data);

        /// <summary>
        /// Clear the pui data cache
        /// </summary>
        public void ClearData() => _data?.Clear();
        #endregion
    }
}