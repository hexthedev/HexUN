using TobiasUN.Core.Events;
using UnityEngine;
using UnityEngine.Events;

namespace TobiasUN.Core.Patterns
{
   [System.Serializable]
   public class CVCommandArrayUnityEvent : UnityEvent<CVCommand[]>
   {
   }
}