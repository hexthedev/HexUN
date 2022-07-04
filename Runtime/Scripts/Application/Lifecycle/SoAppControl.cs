using UnityEngine;

namespace Hex.UN.Runtime.Application.Lifecycle
{
    /// <summary>
    /// Exposes important application control unsing an interface
    /// </summary>
    [CreateAssetMenu(fileName = "AppControl", menuName = "HexUN/Services/AppControl")]
    public class SoAppControl : ScriptableObject, IAppControl
    {
        public void Quit()
        {
            UnityEngine.Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
