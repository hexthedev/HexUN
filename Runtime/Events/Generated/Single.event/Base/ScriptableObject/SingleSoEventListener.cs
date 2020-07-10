using UnityEngine;
using UnityEngine.Events;
using System;

namespace TobiasUN.Core.Events
{
   [AddComponentMenu("TobiasUN/Core/Events/Single/SingleSoEventListener")]
   public class SingleSoEventListener : ScriptableObjectEventListener<Single, SingleSoEvent, SingleUnityEvent>
   {
   }
}