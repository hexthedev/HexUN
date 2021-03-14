using HexUN.Events;

namespace HexUN.Behaviour
{
   [System.Serializable]
   public class MonoDataReliableEvent : ReliableEvent<DataBehaviour, MonoDataUnityEvent>
   {
   }
}