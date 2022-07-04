using UnityEditor;

namespace Hex.UN.Editor.Scripts.Debugging
{



    public static class UTDebug
    {
        [MenuItem("Hex/Utility/Cleanup Missing Scripts")]
        static void CleanupMissingScripts()
        {
            for (int i = 0; i < Selection.gameObjects.Length; i++)
            {
                GameObjectUtility.RemoveMonoBehavioursWithMissingScript(Selection.gameObjects[i]);
            }
        }
    }
}