using Hex.UN.Runtime.Framework.Singletons;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hex.UN.Runtime.SubSystem.Camera
{
    /// <summary>
    /// Automatically takes control of the main camera on start. When Destoryed, puts the camera back in it's own scene.
    /// </summary>
    public class CameraRig : AOneHexScene<CameraRig>
    {
        private const string cCameraSceneName = "CameraResource";
        
        private UnityEngine.Camera _managedCam;
        private Scene _cameraScene;

        private void Start()
        {
            _managedCam = UnityEngine.Camera.main;

            bool isCameraSceneCreated = false;
            for(int i = 0; i<SceneManager.sceneCount; i++)
            {
                if(SceneManager.GetSceneAt(i).name == cCameraSceneName)
                {
                    isCameraSceneCreated = true;
                    break;
                }
            }

            if (!isCameraSceneCreated) _cameraScene = SceneManager.CreateScene(cCameraSceneName);
            else _cameraScene = SceneManager.GetSceneByName(cCameraSceneName);

            _managedCam.transform.SetParent(transform, false);
        }

        [ContextMenu("Button")]
        public void Cam()
        {
            GameObject[] ob = GameObject.FindGameObjectsWithTag("EditorOnly");
            //Start();


        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _managedCam.transform.parent = null;
            SceneManager.MoveGameObjectToScene(_managedCam.gameObject, _cameraScene);
        }
    }
}