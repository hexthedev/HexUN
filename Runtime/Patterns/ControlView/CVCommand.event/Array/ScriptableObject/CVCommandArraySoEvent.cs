using UnityEngine;
using HexUN.Events;

namespace HexUN.Patterns
{
   [CreateAssetMenu(fileName = "CVCommandArraySoEvent", menuName = "HexUN.Patterns/CVCommandArray")]
   public class CVCommandArraySoEvent : ScriptableObjectEvent<CVCommand[]>
   {
   }
}