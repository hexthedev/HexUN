using HexUN.Events;

namespace HexUN.MonoB
{
   [System.Serializable]
   public class MonoDataReliableEvent : ReliableEvent<DataBehaviour, MonoDataUnityEvent>
   {
   }
}