using HexUN.MonoB;
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


        protected override void MonoAwake()
        {
            base.MonoAwake();

            if (!_isActive)
            {
                if (!AppLifecycle.IsBootstrapped) InstantiateResources();
                _isActive = true;
            }
        }

        /// <inheritdoc />
        protected void OnValidate()
        {
            if (!_isActive)
            {
                if (!Application.isPlaying)
                {
                    InstantiateResources();
                    _isActive = true;
                }
            }
        }

        private void InstantiateResources()
        {
            if (_resources == null) return;
            foreach (GameObject ob in _resources)
            {
                GameObject inst = Instantiate(ob, transform);
                inst.hideFlags = HideFlags.DontSave;
            }
        }
    }
}