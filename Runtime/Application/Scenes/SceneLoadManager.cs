using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HexUN.MonoB;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HexUN.App
{
    /// <summary>
    /// Scene tracker is a singleton that tracks the loaded scenes and knows what needs unloading
    /// between scenes
    /// </summary>
    public class SceneLoadManager : AMonoSingletonPersistent<SceneLoadManager>
    {
        private List<SceneToken> _loadedOrLoadingScenes = new List<SceneToken>();

        private Queue<ASceneLoadTask> _sceneTasks = new Queue<ASceneLoadTask>();
        private List<AsyncOperation> _currentOperations = new List<AsyncOperation>();
        private Coroutine _operationCoroutine = null;

        #region API
        public void QueueTasks(params ASceneLoadTask[] tasks)
        {
            if (tasks == null) return;

            foreach(ASceneLoadTask task in tasks) _sceneTasks.Enqueue(task);

            if(_operationCoroutine == null)
            {
                StartCoroutine(HandleSceneQueue());
            }
        }

        #endregion
        private void ResolveQueueHandler()
        {
            if (_operationCoroutine == null)
            {
                _operationCoroutine = StartCoroutine(HandleSceneQueue());
            }
        }

        IEnumerator HandleSceneQueue()
        {
            _currentOperations.Clear();

            while(_sceneTasks.Count > 0)
            {
                ASceneLoadTask task = _sceneTasks.Peek();
                
                if(task.PerformTask(_loadedOrLoadingScenes, _currentOperations))
                {
                    _sceneTasks.Dequeue();
                }

                yield return null;
            }

            _operationCoroutine = null;
        }
    }
}