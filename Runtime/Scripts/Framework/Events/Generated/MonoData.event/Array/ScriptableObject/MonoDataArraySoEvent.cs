using UnityEngine;
using HexUN.Events;

namespace HexUN.Behaviour
{
   [CreateAssetMenu(fileName = "MonoDataArraySoEvent", menuName = "HexUN/Events/MonoDataArray")]
   public class MonoDataArraySoEvent : ScriptableObjectEvent<DataBehaviour[]>
   {
   }
}