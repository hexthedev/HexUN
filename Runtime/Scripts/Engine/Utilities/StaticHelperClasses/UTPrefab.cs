using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Hex.UN.Runtime.Engine.Utilities.StaticHelperClasses
{
    public class UTPrefab
    {
#if UNITY_EDITOR
        /// <summary>
        /// Applyes instance modifications to a prefab parent if there
        /// are any. Otherwise returns false;
        /// </summary>
        public static bool TryApplyOverrides(GameObject instance)
        {
            List<ObjectOverride> modications = PrefabUtility.GetObjectOverrides(instance);

            if (modications.Count == 0) return false;

            foreach(ObjectOverride mod in modications)
            {
                string path = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(mod.GetAssetObject());
                mod.Apply(path, InteractionMode.AutomatedAction);
            }

            return true;
        }
#endif
    }
}