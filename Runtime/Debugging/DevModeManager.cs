using TobiasUN.Core.MonoB;
using UnityEngine;

namespace TobiasUN.Core.Debugging
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
            HideFlags flag = _devmode ? 
                HideFlags.None : 
                HideFlags.HideInHierarchy | HideFlags.HideInInspector;

            foreach (Transform trans in transform)
            {
                if (trans == transform) continue;
                trans.hideFlags = flag;
            }

            if(_devMonobehaviours != null)
            {
                foreach(MonoBehaviour mb in _devMonobehaviours)
                {
                    if(mb != null) mb.hideFlags = flag;
                }
            }
        }
    }
}