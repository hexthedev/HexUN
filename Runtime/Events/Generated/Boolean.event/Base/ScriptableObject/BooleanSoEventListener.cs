using UnityEngine;
using UnityEngine.Events;
using System;

namespace TobiasUN.Core.Events
{
   [AddComponentMenu("TobiasUN/Core/Events/Boolean/BooleanSoEventListener")]
   public class BooleanSoEventListener : ScriptableObjectEventListener<Boolean, BooleanSoEvent, BooleanUnityEvent>
   {
   }
}