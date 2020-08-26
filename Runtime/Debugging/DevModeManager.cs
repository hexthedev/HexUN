using HexUN.MonoB;
using UnityEngine;

namespace HexUN.Debugging
{
    /// <summary>
    /// Handles putting gameobjects in dev mode
    /// </summary>
    public class DevModeManager : MonoEnhanced
    {
        [SerializeField]
        [Tooltip("Show gameobject in dev mode")]
        private bool _devmode = false;

        [SerializeField]
        [Tooltip("Monobehaviours on the same object as the DevModeanager that are hidden by dev mode")]
        private MonoBehaviour[] _devMonobehaviours = null;

        protected virtual void OnValidate()
        {
            UTDevModeManagment.SetDevMode(_devmode, transform, _devMonobehaviours);
        }
    }
}