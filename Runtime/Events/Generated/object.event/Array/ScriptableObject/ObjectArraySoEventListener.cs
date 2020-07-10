using UnityEngine;
using UnityEngine.Events;
using System;

namespace TobiasUN.Core.Events
{
   [AddComponentMenu("TobiasUN/Core/Events/ObjectArray/ObjectArraySoEventListener")]
   public class ObjectArraySoEventListener : ScriptableObjectEventListener<object[], ObjectArraySoEvent, ObjectArrayUnityEvent>
   {
   }
}