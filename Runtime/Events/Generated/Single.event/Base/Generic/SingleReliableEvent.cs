using System;

namespace TobiasUN.Core.Events
{
   [System.Serializable]
   public class SingleReliableEvent : ReliableEvent<Single, SingleUnityEvent>
   {
   }
}