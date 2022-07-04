using UnityEngine;

namespace Hex.UN.Runtime.Application.Scenes.Tasks
{
    /// <summary>
    /// List of tasks executed in order by the SceneLoadManager
    /// </summary>
    [CreateAssetMenu(fileName = "SceneLoadTaskList", menuName = "HexUN/App/Scene/SceneLoadTaskList")]
    public class SceneLoadTaskList : ScriptableObject
    {
        /// <summary>
        /// List of tasks executed in order by the SceneLoadManager
        /// </summary>
        [Tooltip("List of tasks executed in order by the SceneLoadManager")]
        public ASceneLoadTask[] LoadTasks;
    }
}
