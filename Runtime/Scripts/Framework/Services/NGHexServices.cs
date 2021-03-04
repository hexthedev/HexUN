using HexUN.Deps;
using HexUN.Framework.Debugging;
using HexUN.Framework.Services;
using HexUN.MonoB;

using UnityEngine;

namespace HexUN.Framework
{
    /// <summary>
    /// For use in the Hex Framework. Provides application level dependencies
    /// such as logging, etc. Allows for configuration of these components. 
    /// </summary>
    public class NGHexServices : ANGHexPersistent<NGHexServices>
    {
        [SerializeField]
        [Tooltip("Prefab, instance or scriptable object that provides ILog interface dependency to the Unity application")]
        private Object ILog = null;

        [SerializeField]
        [Tooltip("Prefab, instance or scriptable object that provides IMonoCallbacks interface dependency to the Unity application")]
        private Object IMonoCallbacks = null;

        private ILog _log;
        private IMonoCallbacks _monoCallbacks;

#if UNITY_EDITOR
        protected void OnValidate()
        {
            UTDependency.Resolve(ref ILog, out _log, this);
            UTDependency.Resolve(ref IMonoCallbacks, out _monoCallbacks, this);
        }
#endif

        protected override void MonoAwake()
        {
            base.MonoAwake();
            UTDependency.Resolve(ref ILog, out _log, this);
            UTDependency.Resolve(ref IMonoCallbacks, out _monoCallbacks, this);
        }

        #region API
        /// <summary>
        /// Returns the loggin mechanism for the framework
        /// </summary>
        public ILog Log => _log;

        /// <summary>
        /// Provides access to mono behaviour callbacks
        /// </summary>
        private IMonoCallbacks MonoCallbacks => _monoCallbacks;
        #endregion


    }
}