using TobiasUN.Core.Events;

namespace TobiasUN.Core.Patterns
{
   [System.Serializable]
   public class CVCommandReliableEvent : ReliableEvent<CVCommand, CVCommandUnityEvent>
   {
   }
}