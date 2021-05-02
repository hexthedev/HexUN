using HexUN.Behaviour;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexUN.Framework.Input
{
    public class NGInput_Unity : ANGHexPersistent<NGInput_Unity>, IInput
    {
        public bool GetKeyDown(KeyCode key)
        {
            return UnityEngine.Input.GetKeyDown(key);
        }
    }
}