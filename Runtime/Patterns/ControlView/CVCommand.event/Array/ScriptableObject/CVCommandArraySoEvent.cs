using UnityEngine;
using TobiasUN.Core.Events;

namespace TobiasUN.Core.Patterns
{
   [CreateAssetMenu(fileName = "CVCommandArraySoEvent", menuName = "TobiasUN/Core/Patterns/CVCommandArray")]
   public class CVCommandArraySoEvent : ScriptableObjectEvent<CVCommand[]>
   {
   }
}