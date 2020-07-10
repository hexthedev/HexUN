using TobiasCSStandard.Core;
using TobiasUN.Core.MonoB;
using UnityEngine;
using UnityEngine.Events;

namespace TobiasUN.Core.Patterns
{
    /// <summary>
    /// Can be added as a component to any game object ot listen to events. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TScriptableObjectEvent"></typeparam>
    /// <typeparam name="TUnityEvent"></typeparam>
    public class CVCommandListener<T, TUnityEvent> : MonoEnhanced
        where TUnityEvent : UnityEvent<T>, new()
    {
        [SerializeField]
        [Tooltip("The event callback that is called when SO event is invoked")]
        private TUnityEvent _unityEvent = new TUnityEvent();

        #region API
        /// <summary>
        /// The Unity Event
        /// </summary>
        public TUnityEvent UnityEvent => _unityEvent;

        public void Invoke(CVCommand cmd)
        {
            if (!cmd.TryGet(out T result)) return;
            _unityEvent?.Invoke(result);
        }
        #endregion
    }
}