using HexUN.Events;

namespace HexUN.Patterns
{
   [System.Serializable]
   public class CVCommandArrayReliableEvent : ReliableEvent<CVCommand[], CVCommandArrayUnityEvent>
   {
   }
}