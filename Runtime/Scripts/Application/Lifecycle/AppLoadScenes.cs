using UnityEngine;

namespace Hex.UN.Runtime.Application.Lifecycle
{
    [CreateAssetMenu(fileName = "AppLoadScenes", menuName = "HexUN/App/AppLoadScenes") ]
    public class AppLoadScenes : ScriptableObject
    {
        public string LoadingScreen;
        public float MinLoadTime = 2f;
        public string[] TemproaryScenes;
        public string[] PermanentScenes;
    }
}