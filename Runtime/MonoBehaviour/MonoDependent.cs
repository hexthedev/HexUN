using System;
using System.Collections.Generic;
using HexCS.Core;
using UnityEngine;

namespace HexUN.MonoB
{
    /// <summary>
    /// Adds useful functionality to any Monobehaviours that follows the inferface dependency pattern
    /// used commonly in HexUN Control and Views. Allows to
    /// </summary>
    public abstract class MonoDependent : MonoEnhanced
    {
        #region Protected API
        /// <inheritdoc>
        protected override void MonoAwake()
        {
            ResolveDependencies();
            EventBindings.ClearAndUnsubscribeAll();
            ResolveEventBindings(EventBindings);
#if TOBIAS_DEBUG
            LogInfo<MonoDependent>($"Awake complete. Dependencies and EventBindings resolved");
#endif
        }

        /// <inheritdoc>
        protected virtual void OnValidate()
        {
            ResolveDependencies();
            EventBindings.ClearAndUnsubscribeAll();
            ResolveEventBindings(EventBindings);
        }

        /// <summary>
        /// Use UTDependency to resolve serializedObject type variable to
        /// interface containers in the prefab
        /// </summary>
        protected virtual void ResolveDependencies() { }

        /// <summary>
        /// bind events that need to be bound from dependencies. This will occur after
        /// dependencies are resolved
        /// </summary>
        /// <param name="ebs"></param>
        protected virtual void ResolveEventBindings(EventBindingGroup ebs) { }
        #endregion
    }
}