using HexUN.Events;
using UnityEngine;
using UnityEngine.Events;

namespace HexUN.MonoB
{
   [AddComponentMenu("HexUN/Events/MonoData/MonoDataSoEventListener")]
   public class MonoDataSoEventListener : ScriptableObjectEventListener<MonoData, MonoDataSoEvent, MonoDataUnityEvent>
   {
   }
}