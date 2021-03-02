using HexUN.Deps;
using HexUN.Framework.Debugging;
using HexUN.MonoB;

using UnityEngine;

namespace HexUN.Framework
{
    /// <summary>
    /// For use in the Hex Framework. Provides application level dependencies
    /// such as logging, etc. Allows for configuration of these components. 
    /// </summary>
    public class NGHexApp : ANGHexScene<NGHexApp>
    {
        [SerializeField]
        [Tooltip("Prefab or scriptable object that provides ILog interface dependency to the Unity application")]
        private Object ILog = null;

        private ILog _log;

#if UNITY_EDITOR
        protected void OnValidate()
        {
            UTDependency.Resolve(ref ILog, out _log, this);
        }
#endif

        #region API
        /// <summary>
        /// Returns the loggin mechanism for the framework
        /// </summary>
        public ILog Log => _log;
        #endregion


    }
}