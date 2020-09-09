using HexUN.MonoB;
using UnityEngine;

namespace RoboArena
{
    public class CameraRig : AMonoSingletonScene<CameraRig>
    {
        [SerializeField]
        [Tooltip("Where to put camera on destroy. If null, takes the parent of the camera before it was reparented to the rig")]
        private Transform _onDestroyParent = null;

        private Camera _managedCam;

        private void Start()
        {
            _managedCam = Camera.main;
            if (_onDestroyParent == null) _onDestroyParent = _managedCam.transform.parent;
            _managedCam.transform.SetParent(transform, false);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if(_onDestroyParent != null && _managedCam != null) _managedCam.transform.SetParent(null);
        }
    }
}