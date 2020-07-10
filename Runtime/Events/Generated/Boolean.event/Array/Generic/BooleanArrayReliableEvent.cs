using System;

namespace TobiasUN.Core.Events
{
   [System.Serializable]
   public class BooleanArrayReliableEvent : ReliableEvent<Boolean[], BooleanArrayUnityEvent>
   {
   }
}