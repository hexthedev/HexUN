using UnityEngine;

namespace TobiasUN.Core.Dependencies
{
    /// <summary>
    /// Contains useful functions for managing dependencies in Unity
    /// </summary>
    public static class UTDependency
    {
        /// <summary>
        /// Used in scripts as a shortcut to calling TryAsDep, and on failure
        /// setting the ob to null. This means in editor that dragging and object
        /// into a slot it cannot act as a dependency for will set it to null and log
        /// an error
        /// </summary>
        /// <typeparam name="TExpected"></typeparam>
        /// <param name="ob"></param>
        /// <param name="dep"></param>
        public static void Resolve<TExpected>(ref Object ob, out TExpected dep, MonoBehaviour dependentMono = null, bool canBeNull = false)
        {
            if (canBeNull && ob == null)
            {
                dep = default;
                return;
            }

            if (!ob.TryAsDep(out dep, dependentMono)) ob = null;
        }

        /// <summary>
        /// Try to cast the unity object to the dependency type. If fails, logs and error and retursn default
        /// </summary>
        /// <typeparam name="TExpected"></typeparam>
        /// <param name="ob"></param>
        /// <param name="dep"></param>
        /// <returns></returns>
        public static bool TryAsDep<TExpected>(this Object ob, out TExpected dep, MonoBehaviour dependentMono = null) => TryAsDep((object)ob, out dep, dependentMono);

        private static bool TryAsDep<TExpected>(object ob, out TExpected dep, MonoBehaviour dependentMono)
        {
            if(!(ob is TExpected))
            {
                if(dependentMono == null)
                {
                    Debug.LogError($"{ob} dependency extraction failed. {ob} is not type {typeof(TExpected).ToString()}");
                } else
                {
                    Debug.LogError($"{ob} dependency extraction failed for mono {dependentMono} in gameobject {dependentMono.gameObject}. {ob} is not type {typeof(TExpected).ToString()}");
                }

                
                dep = default;
                return false;
            }

            dep = (TExpected)ob;
            return true;
        }
    }
}