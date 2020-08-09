using HexUN.MonoB;
using UnityEditor;
using UnityEngine;

namespace HexUN.App
{
    /// <summary>
    /// Holds the resources required by the scene and provides options on
    /// when they should be enabled or disabled
    /// </summary>
    public class SceneResources : MonoEnhanced
    {
        [Header("Options")]
        [SerializeField]
        private GameObject[] _resources = null;

        private bool _isActive = false;

        private GameObject[] _instances = null;

        protected override void MonoAwake()
        {
            base.MonoAwake();

            if (!_isActive)
            {
                if (!AppManager.IsBootstrapped) InstantiateResources();
                _isActive = true;
            }
        }

        /// <inheritdoc />
        protected void OnValidate()
        {
            if (!_isActive && gameObject.activeInHierarchy)
            {
                if (!Application.isPlaying)
                {
                    InstantiateResources();
                    _isActive = true;
                }
            }
        }

        protected override void OnDestroy() => ClearInstanceCache();

        private void InstantiateResources()
        {
            if (_resources == null) return;
            ClearInstanceCache();

            _instances = new GameObject[_resources.Length];

            for(int i = 0; i<_resources.Length; i++)
            {
#if UNITY_EDITOR
                GameObject inst = (GameObject)PrefabUtility.InstantiatePrefab(_resources[i], transform);
                inst.hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild;
                _instances[i] = inst;
#endif
            }
        }

        private void ClearInstanceCache()
        {
            if (_instances != null)
            {
                foreach (GameObject instance in _instances)
                {
                    DestroyImmediate(instance);
                }
            }
        }
    }
}