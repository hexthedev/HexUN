using UnityEngine;
using UnityEngine.Events;
using System;

namespace HexUN.Events
{
   [AddComponentMenu("HexUN/Core/Events/Boolean/BooleanSoEventListener")]
   public class BooleanSoEventListener : ScriptableObjectEventListener<Boolean, BooleanSoEvent, BooleanUnityEvent>
   {
   }
}