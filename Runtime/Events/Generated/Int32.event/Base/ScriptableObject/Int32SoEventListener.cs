using UnityEngine;
using UnityEngine.Events;
using System;

namespace TobiasUN.Core.Events
{
   [AddComponentMenu("TobiasUN/Core/Events/Int32/Int32SoEventListener")]
   public class Int32SoEventListener : ScriptableObjectEventListener<Int32, Int32SoEvent, Int32UnityEvent>
   {
   }
}