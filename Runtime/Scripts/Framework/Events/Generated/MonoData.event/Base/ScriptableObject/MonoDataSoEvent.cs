using UnityEngine;
using HexUN.Events;

namespace HexUN.MonoB
{
   [CreateAssetMenu(fileName = "MonoDataSoEvent", menuName = "HexUN/Events/MonoData")]
   public class MonoDataSoEvent : ScriptableObjectEvent<DataBehaviour>
   {
   }
}