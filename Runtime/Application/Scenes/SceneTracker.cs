using System.Collections;
using System.Collections.Generic;
using HexUN.MonoB;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HexUN.App
{
    /// <summary>
    /// Scene manager is a singleton that tracks the loaded scenes and knows what needs unloading
    /// between scenes
    /// </summary>
    public class SceneTracker : AMonoSingletonPersistent<SceneTracker>
    {
        [SerializeField]
        private string _loadingScreen = "PTLoad";

        [SerializeField]
        private float _minLoadTime = 2f;

        private List<string> _loadedTemporaryScenes = new List<string>();
        private List<string> _loadedPermanentScenes = new List<string>();

        private Queue<SceneLoadOperation> _sceneOperations = new Queue<SceneLoadOperation>();
        private Coroutine _operationCoroutine = null;


        #region API
        public string LoadingScreen
        {
            get => _loadingScreen;
            set => _loadingScreen = value;
        }

        public float MinLoadTime
        {
            get => _minLoadTime;
            set => _minLoadTime = value;
        }

        /// <summary>
        /// Load a scene and unload all temproary scenes
        /// </summary>
        /// <param name="index"></param>
        /// <param name="isPermanent"></param>
        public void LoadTemporaryScenesAndUnloadOld(params string[] scenes)
        {
            foreach (string scene in scenes)
            {
                _sceneOperations.Enqueue(new SceneLoadOperation() { Scene = scene, IsLoading = true, IsTemporary = true, IsUnloadTemporaries = true });
            }

            ResolveQueueHandler();
        }

        /// <summary>
        /// Load a scene and unload all temproary scenes
        /// </summary>
        /// <param name="index"></param>
        /// <param name="isPermanent"></param>
        public void LoadTemproaryScenesWithoutUnloadOld(params string[] scenes)
        {
            foreach (string scene in scenes)
            {
                _sceneOperations.Enqueue(new SceneLoadOperation() { Scene = scene, IsLoading = true, IsTemporary = true });
            }

            ResolveQueueHandler();
        }

        /// <summary>
        /// Load a scene and unload all temproary scenes
        /// </summary>
        /// <param name="index"></param>
        /// <param name="isPermanent"></param>
        public void LoadPermanentScenes(params string[] scenes)
        {
            foreach(string scene in scenes)
            {
                _sceneOperations.Enqueue(new SceneLoadOperation() { Scene = scene, IsLoading = true });
            }

            ResolveQueueHandler();
        }

        /// <summary>
        /// Unload a scene
        /// </summary>
        public void UnloadScene(string scene)
        {
            _sceneOperations.Enqueue(new SceneLoadOperation() { Scene = scene });
            ResolveQueueHandler();
        }

        /// <summary>
        /// Toggle if the loading screen is active
        /// </summary>
        /// <param name="showLoadingScreen"></param>
        public void ToggleLoadScreen(bool showLoadingScreen)
        {
            if (showLoadingScreen) _sceneOperations.Enqueue(new SceneLoadOperation() { Scene = LoadingScreen, IsLoading = true });
            else _sceneOperations.Enqueue(new SceneLoadOperation() { Scene = LoadingScreen} );
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
            while(_sceneOperations.Count > 0)
            {
                SceneLoadOperation op = _sceneOperations.Dequeue();

                // If we're unloading the load screen but more scene operations are coming up, send it to back
                if(op.Scene == _loadingScreen && !op.IsLoading)
                {
                    if (_sceneOperations.Count > 0)
                    {
                        _sceneOperations.Enqueue(op);
                        continue;
                    }
                }

                // in this case, queue all temporaries for unload and then load this scene 
                if (op.IsUnloadTemporaries)
                {
                    string[] scenesToUnload = _loadedTemporaryScenes.ToArray();
                    foreach (string scene in scenesToUnload)
                    {
                        _sceneOperations.Enqueue(new SceneLoadOperation() { Scene = scene, IsTemporary = true });
                        HandleSceneUnregistration(scene);
                    }

                    _sceneOperations.Enqueue(new SceneLoadOperation() { Scene = op.Scene, IsLoading = true, IsTemporary = op.IsTemporary });
                    continue;
                }

                if (op.IsLoading)
                {
                    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(op.Scene, LoadSceneMode.Additive);

                    while (!asyncLoad.isDone)
                    {
                        yield return null;
                    }

                    HandleSceneRegistration(op.Scene, op.IsTemporary);
                }
                else
                {
                    if (op.Scene == _loadingScreen) yield return new WaitForSeconds(_minLoadTime);
                    AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(op.Scene);

                    while (!asyncLoad.isDone)
                    {
                        yield return null;
                    }

                    HandleSceneUnregistration(op.Scene);
                }
            }

            _operationCoroutine = null;
        }

        private void HandleSceneRegistration(string scene, bool isTemporary)
        {
            if (isTemporary) _loadedTemporaryScenes.Add(scene);
            else _loadedPermanentScenes.Add(scene);
        }

        private void HandleSceneUnregistration(string scene)
        {
            _loadedTemporaryScenes.Remove(scene);
            _loadedPermanentScenes.Remove(scene);
        }

        private class SceneLoadOperation
        {
            public string Scene;
            public bool IsLoading; // otherwise unloading
            public bool IsTemporary; // otherwise temproary
            public bool IsUnloadTemporaries;
        }
    }
}