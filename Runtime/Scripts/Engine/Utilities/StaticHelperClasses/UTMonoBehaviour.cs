using UnityEngine;

namespace HexUN.Engine.Utilities 
{ 
    /// <summary>
    /// Utilities pertaining to mono behaviour type objects
    /// </summary>
    public static class UTMonoBehaviour
    {
        /// <summary>
        /// Adds a child to the monobehaviours gameobject of type TChild 
        /// </summary>
        public static TChild AddChild<TParent, TChild>(this TParent monoBehaviour, string name)
            where TParent: MonoBehaviour
            where TChild: MonoBehaviour
        {
            return monoBehaviour.gameObject.AddChild<TChild>(name);
        }

        /// <summary>
        /// Adds a child to the monobehaviours gameobject of type TChild 
        /// </summary>
        public static void AddChild<TParent, TChild>(this TParent monoBehaviour, string name, out TChild child)
            where TParent : MonoBehaviour
            where TChild : MonoBehaviour
        {
            child = monoBehaviour.gameObject.AddChild<TChild>(name);
        }
    }
}
