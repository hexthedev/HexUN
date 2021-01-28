using UnityEngine;
using HexUN.Events;

namespace HexUN.MonoB
{
   [CreateAssetMenu(fileName = "MonoDataArraySoEvent", menuName = "HexUN/Events/MonoDataArray")]
   public class MonoDataArraySoEvent : ScriptableObjectEvent<MonoData[]>
   {
   }
}