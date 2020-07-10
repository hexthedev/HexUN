using UnityEngine;
using UnityEngine.Events;
using System;

namespace HexUN.Events
{
   [AddComponentMenu("HexUN/Core/Events/SingleArray/SingleArraySoEventListener")]
   public class SingleArraySoEventListener : ScriptableObjectEventListener<Single[], SingleArraySoEvent, SingleArrayUnityEvent>
   {
   }
}