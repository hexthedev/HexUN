using HexUN.Events;

namespace HexUN.MonoB
{
   [System.Serializable]
   public class MonoDataArrayReliableEvent : ReliableEvent<DataBehaviour[], MonoDataArrayUnityEvent>
   {
   }
}