using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.Engine.Utilities
{
    public static class UTGameObject
    {
        /// <summary>
        /// Creates a game object that is completely empty, but has the same
        /// transform and parent as the original go
        /// </summary>
        public static GameObject CopyEmpty(this GameObject go)
        {
            GameObject cp = new GameObject($"{go.name}_EmptyCopy");
            cp.transform.CopyFrom(go.transform);
            return cp;
        }

        public static void DestroyAllChildren(this GameObject go)
        {
            foreach (Transform child in UTTransform.GetAllChildren(go.transform)) Object.Destroy(child);
        }

        public static void DestroyAllChildrenImmediate(this GameObject go)
        {
            foreach (Transform child in UTTransform.GetAllChildren(go.transform)) Object.DestroyImmediate(child.gameObject);
        }
    }
}