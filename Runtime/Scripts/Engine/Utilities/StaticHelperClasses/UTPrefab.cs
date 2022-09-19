using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace Hex.UN.Runtime.Engine.Utilities.StaticHelperClasses
{
    public static class UTPrefab
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
        
        
        /// <summary>
        /// Instantiates a prefab as prefab in editor or normally at runtime
        /// </summary>
        public static GameObject InstantiatePrefab_EditorSafe(this GameObject prefab)
        {
#if UNITY_EDITOR
            GameObject instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            
            if(instance == null)
                Debug.LogError($"Failed to instantiate prefab. Maybe the prefab is not valid or null? value={prefab}");
            
            return instance;
#else
            return Object.Instantiate(prefab);
#endif
        }
        
        /// <summary>
        /// Instantiates a prefab as prefab in editor or normally at runtime
        /// </summary>
        public static GameObject InstantiatePrefab_EditorSafe(this GameObject prefab, Transform t)
        {
#if UNITY_EDITOR
            GameObject instance = PrefabUtility.InstantiatePrefab(prefab, t) as GameObject;
            
            if(instance == null)
                Debug.LogError($"Failed to instantiate prefab. Maybe the prefab is not valid or null? value={prefab}");
            
            return instance;
#else
            return Object.Instantiate(prefab, t);
#endif
        }
        
        /// <summary>
        /// Instantiates a prefab as prefab in editor or normally at runtime
        /// </summary>
        public static T InstantiatePrefab_EditorSafe<T>(this T prefab)
            where T : MonoBehaviour
        {
#if UNITY_EDITOR
            T instance = PrefabUtility.InstantiatePrefab(prefab) as T;
            
            if(instance == null)
                Debug.LogError($"Failed to instantiate prefab. Maybe the prefab is not valid or null? value={prefab}");
            
            return instance;
#else
            return Object.Instantiate(prefab);
#endif
        }
        
        /// <summary>
        /// Instantiates a prefab as prefab in editor or normally at runtime
        /// </summary>
        public static T InstantiatePrefab_EditorSafe<T>(this T prefab, Transform t)
            where T : MonoBehaviour
        {
#if UNITY_EDITOR
            Object instance = PrefabUtility.InstantiatePrefab(prefab, t);
            T cast = instance as T;
            
            if(cast == null)
                Debug.LogError($"Failed to instantiate prefab. Maybe the prefab is not valid or null? value={prefab}");
            
            return cast;
#else
            return Object.Instantiate(prefab, t);
#endif
        }
    }
}