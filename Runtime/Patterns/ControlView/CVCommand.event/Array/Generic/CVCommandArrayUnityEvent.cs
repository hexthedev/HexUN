using HexUN.Events;
using UnityEngine;
using UnityEngine.Events;

namespace HexUN.Patterns
{
   [System.Serializable]
   public class CVCommandArrayUnityEvent : UnityEvent<CVCommand[]>
   {
   }
}