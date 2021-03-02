using System;
using HexCS.Core;
using HexUN.MonoB;
using UnityEngine;
using Event = HexCS.Core.Event;

namespace HexUN.App
{
    /// <summary>
    /// App Manager should always be the first resources loaded by an application. This singleton
    /// manages the loading of all subsequent resources and exists in the application providing 
    /// global application level apis. The update functions of this monobehaviour act at a global levle relative
    /// to the application, and can have function registered to them
    /// </summary>
    public class AppManager : ANGHexPersistent<AppManager>
    {
        [SerializeField]
        [Tooltip("Has the application been bootstrapped. If true, then dev scene resources will not enable themselves assuming that these resources were created during bootstrapping")]
        private bool _isBootstrapped = false;

        [SerializeField]
        [Tooltip("The scene loads that should occur when the application starts")]
        private SceneLoadTaskList _appInitSceneTasks;

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

        /// <summary>
        /// Quit the application
        /// </summary>
        public void QuitApp()
        {
            Application.Quit();
#if UNITY_EDITOR
            Debug.Log("Application.Quit() does nothing in play mode. Just, pretend the app quit I guess");
#endif
        }
        #endregion

        protected override void MonoStart()
        {
            base.MonoStart();

            if(_appInitSceneTasks != null)
            {
                SceneLoadManager.Instance.QueueTasks(_appInitSceneTasks.LoadTasks);
            }
        }

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