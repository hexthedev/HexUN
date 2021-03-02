using HexUN.Events;
using UnityEngine;
using UnityEngine.Events;

namespace HexUN.MonoB
{
   [AddComponentMenu("HexUN/Events/MonoDataArray/MonoDataArraySoEventListener")]
   public class MonoDataArraySoEventListener : ScriptableObjectEventListener<DataBehaviour[], MonoDataArraySoEvent, MonoDataArrayUnityEvent>
   {
   }
}