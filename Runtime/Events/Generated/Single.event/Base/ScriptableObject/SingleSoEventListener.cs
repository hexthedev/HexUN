using UnityEngine;
using UnityEngine.Events;
using System;

namespace HexUN.Events
{
   [AddComponentMenu("HexUN/Core/Events/Single/SingleSoEventListener")]
   public class SingleSoEventListener : ScriptableObjectEventListener<Single, SingleSoEvent, SingleUnityEvent>
   {
   }
}