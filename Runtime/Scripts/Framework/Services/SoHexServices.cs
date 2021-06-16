using HexUN.App;
using HexUN.Framework.Debugging;
using HexUN.Framework.Input;

using UnityEngine;

namespace HexUN.Framework.Services
{
    [CreateAssetMenu(fileName = "HexServices", menuName = "HexUN/Services/HexServices")]
    public class SoHexServices : ScriptableObject, IHexServices
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

#region API
        /// <summary>
        /// Provides access to application control singleton
        /// </summary>
        public IAppControl AppControl => GetInterface<IAppControl>(ref IAppControl);

        /// <summary>
        /// Returns the loggin mechanism for the framework
        /// </summary>
        public ILog Log => GetInterface<ILog>(ref ILog);

        /// <summary>
        /// Provides access to mono behaviour callbacks
        /// </summary>
        public IMonoCallbacks MonoCallbacks => GetInterface<IMonoCallbacks>(ref IMonoCallbacks);

        /// <summary>
        /// Provides access to mono behaviour callbacks
        /// </summary>
        public IInput Input => GetInterface<IInput>(ref IInput);

        public T GetInterface<T>(ref Object candidate) where T : class
        {
            if (candidate == null)
            {
                Debug.LogWarning($"[{nameof(SoHexServices)}] contains a null Object reference to {nameof(T)} when it should be populated");
                return default;
            }

            T instance = candidate as T;

            if(instance == null)
            {
                Debug.LogWarning($"[{nameof(SoHexServices)}] contains an Object reference that does not cast to {nameof(T)} when it should");
                return default;
            }

            return instance;
        }
#endregion




    }
}