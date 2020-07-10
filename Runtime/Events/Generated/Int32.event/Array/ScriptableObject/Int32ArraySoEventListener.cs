using UnityEngine;
using UnityEngine.Events;
using System;

namespace TobiasUN.Core.Events
{
   [AddComponentMenu("TobiasUN/Core/Events/Int32Array/Int32ArraySoEventListener")]
   public class Int32ArraySoEventListener : ScriptableObjectEventListener<Int32[], Int32ArraySoEvent, Int32ArrayUnityEvent>
   {
   }
}