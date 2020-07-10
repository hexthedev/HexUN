using HexUN.Events;
using UnityEngine;
using UnityEngine.Events;

namespace HexUN.Patterns
{
   [AddComponentMenu("HexUN.Patterns/CVCommandArray/CVCommandArraySoEventListener")]
   public class CVCommandArraySoEventListener : ScriptableObjectEventListener<CVCommand[], CVCommandArraySoEvent, CVCommandArrayUnityEvent>
   {
   }
}