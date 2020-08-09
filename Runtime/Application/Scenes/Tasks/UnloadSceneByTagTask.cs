using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HexUN.App
{
    /// <summary>
    /// Unload all scene with a tag
    /// </summary>
    [CreateAssetMenu(fileName = "UnloadScenesByTagTask", menuName = "HexUN/App/Scene/Tasks/UnloadScenesByTagTask")]
    public class UnloadScenesByTagTask : ASceneLoadTask
    {
        public string Tag;

        public UnloadScenesByTagTask(string tag) => Tag = tag;

        public override bool PerformTask(List<SceneToken> currentScenes, List<AsyncOperation> currentTasks)
        {
            foreach (SceneToken t in currentScenes.Where(e => e.Tag == Tag))
            {
                AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(t.Name);
                currentTasks.Add(asyncLoad);
            }

            // Remove the scenes that are being unloaded
            foreach (SceneToken rem in currentScenes.Where(e => e.Tag == Tag)) currentScenes.Remove(rem);

            return true;
        }
    }
}
