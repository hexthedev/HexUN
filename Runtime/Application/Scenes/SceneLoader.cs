using System.Collections;
using HexUN.MonoB;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HexUN.App
{
    /// <summary>
    /// Loads scenes
    /// </summary>
    public class SceneLoader : MonoEnhanced
    {
        [SerializeField]
        [Tooltip("The scene to load")]
        private string[] _scenes = null;

        [SerializeField]
        [Tooltip("is this a temproary scene load or permanent scene load")]
        private bool _isPermanent = false;

        [SerializeField]
        [Tooltip("Should these scens unload the old scenes, only availbe if temproary scene")]
        private bool _isUnloadOld = false;


        public void LoadScene()
        {
            if (_isPermanent)
            {
                SceneTracker.Instance.LoadPermanentScenes(_scenes);
                return;
            }

            if (!_isUnloadOld) 
            {
                SceneTracker.Instance.LoadTemproaryScenesWithoutUnloadOld(_scenes);
                return;
            }

            SceneTracker.Instance.ToggleLoadScreen(true);
            SceneTracker.Instance.LoadTemporaryScenesAndUnloadOld(_scenes);
            SceneTracker.Instance.ToggleLoadScreen(false);
        }
    }
}