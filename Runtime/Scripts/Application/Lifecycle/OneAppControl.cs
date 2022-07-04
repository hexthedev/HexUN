using Hex.UN.Runtime.Framework.Singletons;

namespace Hex.UN.Runtime.Application.Lifecycle
{
    /// <summary>
    /// Exposes important application control unsing an interface
    /// </summary>
    public class OneAppControl : AOneHexPersistent<OneAppControl>, IAppControl
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