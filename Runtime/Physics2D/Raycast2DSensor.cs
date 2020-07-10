using System.Collections;
using UnityEngine;

namespace HexUN.Physics2D
{
    /// <summary>
    /// Performs a raycast from a point for a distance when 
    /// Sense() is called
    /// </summary>
    public class Raycast2DSensor : MonoBehaviour
    {
        [Header("Options")]
        [SerializeField]
        Vector3 _offset = default;

        [SerializeField]
        Vector3 _ray = default;

        private bool _sensedThisFrame = false;
        private RaycastHit2D _lastResult;

#if UNITY_EDITOR
        private bool _sensedThisFrameGizmos = false;
#endif

        public RaycastHit2D Sense()
        {
            if (!_sensedThisFrame) SenseThisFrame();
            return _lastResult;
        }

        private void SenseThisFrame()
        {
            _lastResult = UnityEngine.Physics2D.Raycast(transform.position + _offset, _ray, _ray.magnitude);
            _sensedThisFrame = true;
            StartCoroutine(SensedThisFrame());
#if UNITY_EDITOR
            _sensedThisFrameGizmos = true;
#endif
    }

    IEnumerator SensedThisFrame()
        {
            yield return new WaitForEndOfFrame();
            _sensedThisFrame = false;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Color col = Gizmos.color;
            Gizmos.color = _sensedThisFrameGizmos ? Color.green : Color.white;
            _sensedThisFrameGizmos = false;
            Gizmos.DrawLine(transform.position + _offset, transform.position + _offset + _ray);
            Gizmos.color = col;
        }

        [ContextMenu("Sense")]
        public void CMSense()
        {
            RaycastHit2D h = Sense();
            Debug.Log($"Sensor on {gameObject} sensed {h.collider}");
        }
#endif
    }
}