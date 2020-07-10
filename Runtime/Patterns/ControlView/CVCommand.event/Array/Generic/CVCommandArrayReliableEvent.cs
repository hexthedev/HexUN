using TobiasUN.Core.Events;

namespace TobiasUN.Core.Patterns
{
   [System.Serializable]
   public class CVCommandArrayReliableEvent : ReliableEvent<CVCommand[], CVCommandArrayUnityEvent>
   {
   }
}