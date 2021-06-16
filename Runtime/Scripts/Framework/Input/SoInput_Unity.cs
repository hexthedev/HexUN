using UnityEngine;

namespace HexUN.Framework.Input
{
    [CreateAssetMenu(fileName = "Input_Unity", menuName = "HexUN/Services/Input_Unity")]
    public class SoInput_Unity : ScriptableObject, IInput
    {
        public bool GetKeyDown(KeyCode key)
        {
            return UnityEngine.Input.GetKeyDown(key);
        }
    }
}