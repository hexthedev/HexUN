using TobiasUN.Core.Events;
using UnityEngine;
using UnityEngine.Events;

namespace TobiasUN.Core.Patterns
{
   [AddComponentMenu("TobiasUN/Core/Patterns/CVCommandArray/CVCommandArraySoEventListener")]
   public class CVCommandArraySoEventListener : ScriptableObjectEventListener<CVCommand[], CVCommandArraySoEvent, CVCommandArrayUnityEvent>
   {
   }
}