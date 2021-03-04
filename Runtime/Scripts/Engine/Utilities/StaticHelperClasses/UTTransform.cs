using UnityEngine;

namespace HexUN.Engine
{
    /// <summary>
    /// Useful helper classes for transforms
    /// </summary>
    public static class UTTransform
    {
        /// <summary>
        /// Sets the pos, rot and scale of the transform in local space
        /// </summary>
        public static void Set(this Transform target, Vector3 pos, Quaternion rot, Vector3 scale)
        {
            target.position = pos;
            target.localRotation = rot;
            target.localScale = scale;
        }
    }
}