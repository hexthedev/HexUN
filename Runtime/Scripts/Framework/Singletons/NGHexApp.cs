using HexUN.Deps;
using HexUN.MonoB;

using UnityEngine;

namespace HexUN.Framework
{
    /// <summary>
    /// For use in the Hex Framework. Provides application level dependencies
    /// such as logging, etc. Allows for configuration of these components. 
    /// </summary>
    public class NGHexApp : ANGHexScene<NGHexApp>
    {
        [SerializeField]
        [Tooltip("Prefab or scriptable object that provides ILog interface dependency to the Unity application")]
        private GameObject ILog = null;


        UTDependency



    }
}