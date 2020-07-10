using UnityEngine;
using UnityEngine.Events;
using System;

namespace TobiasUN.Core.Events
{
   [AddComponentMenu("TobiasUN/Core/Events/SingleArray/SingleArraySoEventListener")]
   public class SingleArraySoEventListener : ScriptableObjectEventListener<Single[], SingleArraySoEvent, SingleArrayUnityEvent>
   {
   }
}