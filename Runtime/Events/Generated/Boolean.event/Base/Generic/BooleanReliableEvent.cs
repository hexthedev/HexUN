using System;

namespace TobiasUN.Core.Events
{
   [System.Serializable]
   public class BooleanReliableEvent : ReliableEvent<Boolean, BooleanUnityEvent>
   {
   }
}