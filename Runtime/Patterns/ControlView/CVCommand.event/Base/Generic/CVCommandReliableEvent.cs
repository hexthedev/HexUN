using HexUN.Events;

namespace HexUN.Patterns
{
   [System.Serializable]
   public class CVCommandReliableEvent : ReliableEvent<CVCommand, CVCommandUnityEvent>
   {
   }
}