using UnityEngine;
using TobiasUN.Core.Events;

namespace TobiasUN.Core.Patterns
{
   [CreateAssetMenu(fileName = "CVCommandSoEvent", menuName = "TobiasUN/Core/Patterns/CVCommand")]
   public class CVCommandSoEvent : ScriptableObjectEvent<CVCommand>
   {
   }
}