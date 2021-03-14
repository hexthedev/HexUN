using HexUN.Events;

namespace HexUN.Behaviour
{
   [System.Serializable]
   public class MonoDataArrayReliableEvent : ReliableEvent<DataBehaviour[], MonoDataArrayUnityEvent>
   {
   }
}