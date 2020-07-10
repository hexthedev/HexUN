using System;

namespace TobiasUN.Core.Events
{
   [System.Serializable]
   public class ObjectArrayReliableEvent : ReliableEvent<object[], ObjectArrayUnityEvent>
   {
   }
}