using System.Collections.Generic;
using UnityEngine;

namespace HexUN.MonoB
{
    /// <summary>
    /// Abstract class for all controls
    /// </summary>
    public abstract class DataBehaviour : HexBehaviour
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
        protected List<object> _data = new List<object>();

        protected override void MonoAwake()
        {
            base.MonoAwake();
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
        public List<T> GetAllData<T>()
        {
            List<T> data = new List<T>();

            foreach (object obj in _data)
            {
                if (obj is T)
                {
                    data.Add((T)obj);
                }
            }

            return data;
        }

        /// <summary>
        /// Add a pui data to the data. Will override old data of the same type of exists
        /// </summary>
        /// <param name="data"></param>
        public void AddData(object data, bool removeOthersOfType = true)
        {
            if (_data == null) _data = new List<object>();

            if (removeOthersOfType)
            {
                for(int i = _data.Count - 1; i>=0; i--)
                {
                    if (Data[i].GetType() == data.GetType()) _data.RemoveAt(i);
                }
            }

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

#if UNITY_EDITOR
        /// <summary>
        /// Performs a get all data assuming that Awake has not been called. Only works in editor
        /// </summary>
        public List<T> GetAllDataEditor<T>()
        {
            List<object> objList = new List<object>(_data);
            objList.AddRange(_genericSoData);

            List<T> data = new List<T>();

            foreach (object obj in objList)
            {
                if (obj is T)
                {
                    data.Add((T)obj);
                }
            }

            return data;
        }
#endif
        #endregion
    }
}