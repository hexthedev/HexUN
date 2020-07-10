using UnityEngine;

namespace TobiasUN.Core.App
{
    public class AppQuitter : MonoBehaviour
    {
        public void QuitApp()
        {
            Application.Quit();
#if UNITY_EDITOR
            Debug.Log("Application.Quit() does nothing in play mode. Just, pretend the app quit I guess");
#endif
        }
    }
}