using HexUN.MonoB;
using UnityEngine;

namespace HexUN.App
{
    /// <summary>
    /// Loads initial scenes of the application
    /// </summary>
    public class SceneBootstrapper : MonoEnhanced
    {
        [SerializeField]
        private AppLoadScenes _loadScenes = null;

        protected override void MonoStart()
        {
            base.MonoStart();
            SceneTracker.Instance.LoadingScreen = _loadScenes.LoadingScreen;
            SceneTracker.Instance.ToggleLoadScreen(true);

            if (_loadScenes.PermanentScenes != null && _loadScenes.PermanentScenes.Length != 0)
            {
                SceneTracker.Instance.LoadPermanentScenes(_loadScenes.PermanentScenes);
            }

            SceneTracker.Instance.LoadTemporaryScenesAndUnloadOld(_loadScenes.TemproaryScenes);
            SceneTracker.Instance.ToggleLoadScreen(false);
        }
    }
}