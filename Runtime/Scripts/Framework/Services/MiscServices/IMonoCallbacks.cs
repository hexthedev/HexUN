using HexCS.Core;

using System.Collections;

using UnityEngine;

namespace HexUN.Framework.Services
{
    /// <summary>
    /// Services providing global registration for basic 
    /// monobehaviour lifecycle callbacks
    /// </summary>
    public interface IMonoCallbacks
    {
        /// <summary>
        /// Subscriber for Update functions
        /// </summary>
        IEventSubscriber OnUpdate { get; }

        /// <summary>
        /// Subscriber for LateUpdate functions
        /// </summary>
        IEventSubscriber OnLateUpdate { get; }

        /// <summary>
        /// Subscriber for fixed update functions
        /// </summary>
        IEventSubscriber OnFixedUpdate { get; }

        /// <summary>
        /// Start a coroutine on a global mono
        /// </summary>
        public Coroutine StartCoroutine(IEnumerator coroutine);

        /// <summary>
        /// Stop a coroutine on a global mono
        /// </summary>
        public void StopCoroutine(Coroutine routine);
    }
}