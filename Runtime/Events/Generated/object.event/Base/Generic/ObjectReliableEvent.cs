using System;

namespace TobiasUN.Core.Events
{
   [System.Serializable]
   public class ObjectReliableEvent : ReliableEvent<object, ObjectUnityEvent>
   {
   }
}