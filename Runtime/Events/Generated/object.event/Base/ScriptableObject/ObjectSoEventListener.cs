using UnityEngine;
using UnityEngine.Events;
using System;

namespace TobiasUN.Core.Events
{
   [AddComponentMenu("TobiasUN/Core/Events/Object/ObjectSoEventListener")]
   public class ObjectSoEventListener : ScriptableObjectEventListener<object, ObjectSoEvent, ObjectUnityEvent>
   {
   }
}