using System;
using TobiasCSStandard.Core;
using HexUN.MonoB;
using UnityEngine;
using Event = TobiasCSStandard.Core.Event;

namespace HexUN.App
{
    /// <summary>
    /// Allows functions to be statically subscribed to application events.
    /// Built with disposing of resources at applicaiton quit in mind
    /// </summary>
    public class AppLifecycle : AMonoSingletonPersistent<AppLifecycle>
    {
        [SerializeField]
        [Tooltip("Has the application been bootstrapped. If true, then dev scene resources will not enable themselves assuming that these resources were created during bootstrapping")]
        private bool _isBootstrapped = false;

        private Event _applicationQuitEvents = new Event();

        #region Static API
        /// <summary>
        /// Has bootstrapping been performed to load the application. If so, scene resources shoudl not be loaded
        /// as it is the responsiblity of the bootstrapper to load those resources
        /// </summary>
        public static bool IsBootstrapped => Instance._isBootstrapped;
        
        /// <summary>
        /// Subscribe a function to be called when applicaiton quits
        /// </summary>
        /// <param name="action">action to call</param>
        public static EventBinding SubscribeApplicationQuit(Action action)
        {
            return Instance.SubscribeApplicationQuitInstance(action);
        }
        #endregion
        
        private EventBinding SubscribeApplicationQuitInstance(Action action)
        {
            EventBinding bind = _applicationQuitEvents.Subscribe(action);
            EventBindings.Add(bind);
            return bind;
        }

        private void OnApplicationQuit()
        {
            _applicationQuitEvents.Invoke();
        }
    }
}