using HexCS.Core;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Event = HexCS.Core.Event;

namespace HexUN.Framework.Services
{
    [CreateAssetMenu(fileName ="MonoCallbacks", menuName = "HexUN/Services/MonoCallbacks")]
    public class SoMonoCallbacks : ScriptableObject, IMonoCallbacks
    {
        private Event _OnUpdate = new Event();

        private Event _OnLateUpdate = new Event();

        private Event _OnFixedUpdate = new Event();

        #region API
        /// <summary>
        /// Subscriber for Update functions
        /// </summary>
        public IEventSubscriber OnUpdate => _OnUpdate;

        /// <summary>
        /// Subscriber for LateUpdate functions
        /// </summary>
        public IEventSubscriber OnLateUpdate => _OnLateUpdate;

        /// <summary>
        /// Subscriber for fixed update functions
        /// </summary>
        public IEventSubscriber OnFixedUpdate => _OnFixedUpdate;
        #endregion

        private void Update()
        {
            _OnUpdate.Invoke();
        }

        private void LateUpdate()
        {
            _OnLateUpdate.Invoke();
        }

        private void FixedUpdate()
        {
            _OnFixedUpdate.Invoke();
        }

        public Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return null;
        }

        public void StopCoroutine(Coroutine routine)
        {

        }
    }
}