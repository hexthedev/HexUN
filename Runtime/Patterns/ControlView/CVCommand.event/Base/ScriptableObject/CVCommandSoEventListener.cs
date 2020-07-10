using HexUN.Events;
using UnityEngine;
using UnityEngine.Events;

namespace HexUN.Patterns
{
   [AddComponentMenu("HexUN.Patterns/CVCommand/CVCommandSoEventListener")]
   public class CVCommandSoEventListener : ScriptableObjectEventListener<CVCommand, CVCommandSoEvent, CVCommandUnityEvent>
   {
   }
}