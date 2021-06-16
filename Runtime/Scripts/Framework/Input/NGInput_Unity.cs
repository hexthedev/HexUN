using HexUN.Behaviour;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.Framework.Input
{
    public class NgInput_Unity : ANgHexPersistent<NgInput_Unity, IInput>, IInput
    {
        public bool GetKeyDown(KeyCode key)
        {
            return UnityEngine.Input.GetKeyDown(key);
        }
    }
}