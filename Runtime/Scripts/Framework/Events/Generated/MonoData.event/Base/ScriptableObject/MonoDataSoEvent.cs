using UnityEngine;
using HexUN.Events;

namespace HexUN.Behaviour
{
   [CreateAssetMenu(fileName = "MonoDataSoEvent", menuName = "HexUN/Events/MonoData")]
   public class MonoDataSoEvent : ScriptableObjectEvent<DataBehaviour>
   {
   }
}