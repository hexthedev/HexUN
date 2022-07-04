﻿using Hex.UN.Runtime.Application.Scenes.Tasks;
using Hex.UN.Runtime.Framework.HexBehaviour;
using UnityEngine;

namespace Hex.UN.Runtime.Application.Scenes
{
    /// <summary>
    /// Loads scenes
    /// </summary>
    public class SceneLoader : HexBehaviour
    {
        [SerializeField]
        [Tooltip("Scene load instruction")]
        private SceneLoadTaskList _tasks = null;

        public void LoadScene()
        {
            if (_tasks == null) return;
            SceneLoadManager.Instance.QueueTasks(_tasks.LoadTasks);
        }
    }
}