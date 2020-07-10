using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TobiasUN.Core.App
{
    [CreateAssetMenu(fileName = "AppLoadScenes", menuName = "TobiasUN/Core/App/AppLoadScenes") ]
    public class AppLoadScenes : ScriptableObject
    {
        public string LoadingScreen;
        public float MinLoadTime = 2f;
        public string[] TemproaryScenes;
        public string[] PermanentScenes;
    }
}