using Hex.UN.Runtime.Framework.Events;
using Hex.UN.Runtime.SubSystem.Physics2D._events.SForce2D.@event.Base.Generic;
using UnityEngine;

namespace Hex.UN.Runtime.SubSystem.Physics2D._events.SForce2D.@event.Base.ScriptableObject
{
   [AddComponentMenu("HexUN/Physics2D/Events/SForce2D/SForce2DSoEventListener")]
   public class SForce2DSoEventListener : ScriptableObjectEventListener<_structs.SForce2D, SForce2DSoEvent, SForce2DUnityEvent>
   {
   }
}