using UnityEngine;
using UnityEngine.Events;
using System;

namespace HexUN.Events
{
   [AddComponentMenu("HexUN/Core/Events/BooleanArray/BooleanArraySoEventListener")]
   public class BooleanArraySoEventListener : ScriptableObjectEventListener<Boolean[], BooleanArraySoEvent, BooleanArrayUnityEvent>
   {
   }
}