using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HexUN.Debugging
{



    public static class UTDebug
    {
        [MenuItem("Tobias/Utility/Cleanup Missing Scripts")]
        static void CleanupMissingScripts()
        {
            for (int i = 0; i < Selection.gameObjects.Length; i++)
            {
                GameObjectUtility.RemoveMonoBehavioursWithMissingScript(Selection.gameObjects[i]);
            }
        }
    }
}