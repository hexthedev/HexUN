using HexUN.Behaviour;

using UnityEngine;

namespace HexUN.App
{
    /// <summary>
    /// Exposes important application control unsing an interface
    /// </summary>
    public class NgAppControl : AOneHexPersistent<NgAppControl, IAppControl>, IAppControl
    {
        public void Quit()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}