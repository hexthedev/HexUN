using UnityEngine;
using HexUN.Events;

namespace HexUN.Patterns
{
   [CreateAssetMenu(fileName = "CVCommandSoEvent", menuName = "HexUN.Patterns/CVCommand")]
   public class CVCommandSoEvent : ScriptableObjectEvent<CVCommand>
   {
   }
}