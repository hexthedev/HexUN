using TobiasUN.Core.Events;
using UnityEngine;
using UnityEngine.Events;

namespace TobiasUN.Core.Patterns
{
   [AddComponentMenu("TobiasUN/Core/Patterns/CVCommand/CVCommandSoEventListener")]
   public class CVCommandSoEventListener : ScriptableObjectEventListener<CVCommand, CVCommandSoEvent, CVCommandUnityEvent>
   {
   }
}