using System;

namespace TobiasUN.Core.Events
{
   [System.Serializable]
   public class SingleArrayReliableEvent : ReliableEvent<Single[], SingleArrayUnityEvent>
   {
   }
}