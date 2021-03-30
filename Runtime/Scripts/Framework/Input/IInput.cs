using UnityEngine;

namespace HexUN.Framework.Input
{
    /// <summary>
    /// interface to interact with global input systems. Lets 
    /// HexUN stuff communicate with Input Systems no matter what the type
    /// </summary>
    public interface IInput
    {
        /// <summary>
        /// True if key was down at start of frame
        /// </summary>
        public bool GetKeyDown(KeyCode key);
    }
}