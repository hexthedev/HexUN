using UnityEngine;
using UnityEngine.Events;
using System;

namespace TobiasUN.Core.Events
{
   [AddComponentMenu("TobiasUN/Core/Events/BooleanArray/BooleanArraySoEventListener")]
   public class BooleanArraySoEventListener : ScriptableObjectEventListener<Boolean[], BooleanArraySoEvent, BooleanArrayUnityEvent>
   {
   }
}