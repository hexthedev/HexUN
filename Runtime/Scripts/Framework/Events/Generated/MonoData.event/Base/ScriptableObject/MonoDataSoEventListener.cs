using HexUN.Events;
using UnityEngine;
using UnityEngine.Events;

namespace HexUN.Behaviour
{
   [AddComponentMenu("HexUN/Events/MonoData/MonoDataSoEventListener")]
   public class MonoDataSoEventListener : ScriptableObjectEventListener<DataBehaviour, MonoDataSoEvent, MonoDataUnityEvent>
   {
   }
}