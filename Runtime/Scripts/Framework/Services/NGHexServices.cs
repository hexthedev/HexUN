using HexUN.Deps;
using HexUN.Framework.Debugging;
using HexUN.Framework.Services;
using HexUN.Behaviour;

using UnityEngine;
using HexUN.App;
using HexUN.Framework.Input;

namespace HexUN.Framework
{
    /// <summary>
    /// For use in the Hex Framework. Provides application level dependencies
    /// such as logging, etc. Allows for configuration of these components. 
    /// </summary>
    public class NGHexServices : ANGHexPersistent<NGHexServices>
    {
        [SerializeField]
        [Tooltip("Prefab, instance or scriptable object that provides App Lifecycle Control functions")]
        private Object IAppControl = null;

        [SerializeField]
        [Tooltip("Prefab, instance or scriptable object that provides ILog interface dependency to the Unity application")]
        private Object ILog = null;

        [SerializeField]
        [Tooltip("Prefab, instance or scriptable object that provides IMonoCallbacks interface dependency to the Unity application")]
        private Object IMonoCallbacks = null;

        [SerializeField]
        [Tooltip("Prefab, instance or scriptable object that provides IInput interface dependency to the Unity application")]
        private Object IInput = null;

        private IAppControl _appControl;
        private ILog _log;
        private IMonoCallbacks _monoCallbacks;
        private IInput _input;

#if UNITY_EDITOR
        protected void OnValidate()
        {
            DoResolves();
        }
#endif

        protected override void HexAwake()
        {
            base.HexAwake();
            DoResolves();
        }

        #region API
        /// <summary>
        /// Provides access to application control singleton
        /// </summary>
        public IAppControl AppControl => GetService<IAppControl, NGAppControl>(ref _appControl);

        /// <summary>
        /// Returns the loggin mechanism for the framework
        /// </summary>
        public ILog Log => GetService<ILog, NGHexLog>(ref _log);

        /// <summary>
        /// Provides access to mono behaviour callbacks
        /// </summary>
        public IMonoCallbacks MonoCallbacks => GetService<IMonoCallbacks, NGMonoCallbacks>(ref _monoCallbacks);

        /// <summary>
        /// Provides access to mono behaviour callbacks
        /// </summary>
        public IInput Input => GetService<IInput, NGInput_Unity>(ref _input);
        #endregion

        private TService GetService<TService, TDefault>(ref TService expected)
            where TDefault: ANGHexPersistent<TDefault>, TService
        {
            if (expected == null) expected = ANGHexPersistent<TDefault>.Instance;
            return expected;
        }

        private void DoResolves()
        {
            UTDependency.Resolve(ref ILog, out _log, this);
            UTDependency.Resolve(ref IMonoCallbacks, out _monoCallbacks, this);
            UTDependency.Resolve(ref IAppControl, out _appControl, this);
            UTDependency.Resolve(ref IInput, out _input, this);
        }
    }
}