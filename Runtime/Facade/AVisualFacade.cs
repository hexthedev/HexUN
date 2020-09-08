using UnityEngine;
using HexUN.Debugging;
using HexUN.Render;

#if UNITY_EDITOR
using UnityEditor.Experimental.SceneManagement;
#endif

namespace HexUN.Facade
{
    /// <summary>
    /// AMonoFacade is a MonoBehaviour that hides children members when not in edit mode. 
    /// The intention is that that MonoBehaviour controls the children elements enough
    /// that the developer never needs to edit the children. If the children need editing to create
    /// a MonoFacade prefab, then prefab mode can be used to see the children.
    /// </summary>
    public abstract class AVisualFacade : AVisualObject
    {
        [Header("Facade Control (AMonoFacade)")]
        [Tooltip("Allows modification of children elements")]
        [SerializeField]
        private bool _editMode = false;

        #region Protected API
        [SerializeField]
        [Tooltip("References any mono behaviours that are siblings of the facade, and are important for it's function. Hides them when not in use")]
        protected MonoBehaviour[] _hiddenSiblings = null;

        protected virtual void OnValidate()
        {
#if UNITY_EDITOR
            PrefabStage s = PrefabStageUtility.GetCurrentPrefabStage();
            UTDevModeManagment.SetDevMode(_editMode || s != null, transform, _hiddenSiblings);
#endif
        }
        #endregion
    }
}
