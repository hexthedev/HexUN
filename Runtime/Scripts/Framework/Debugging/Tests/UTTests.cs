#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace HexUN.Framework.Debugging
{
    public static class UTTests
    {

        public static void SetupHexServices()
        {
#if UNITY_EDITOR
            string[] ids = AssetDatabase.FindAssets("OneHexServices");
            string prefabPath = AssetDatabase.GUIDToAssetPath(ids[0]);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            Object.Instantiate(prefab);
#else
            Object.Instantiate(Resources.Load("OneHexServices") as GameObject);
#endif
        }

        /// <summary>
        /// Prints a generic test log to the unity log 
        /// </summary>
        public static void Log(string test, bool result)
        {
            if (result)
            {
                Debug.Log($"[SUCCESS] {test}");
            }
            else
            {
                Debug.LogWarning($"[FAIL] {test}");
            }
        }
    }
}