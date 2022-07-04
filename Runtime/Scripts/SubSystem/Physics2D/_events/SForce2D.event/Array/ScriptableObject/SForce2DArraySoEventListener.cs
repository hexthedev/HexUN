using Hex.UN.Runtime.Framework.Events;
using Hex.UN.Runtime.SubSystem.Physics2D._events.SForce2D.@event.Array.Generic;
using UnityEngine;

namespace Hex.UN.Runtime.SubSystem.Physics2D._events.SForce2D.@event.Array.ScriptableObject
{
   [AddComponentMenu("HexUN/Physics2D/Events/SForce2DArray/SForce2DArraySoEventListener")]
   public class SForce2DArraySoEventListener : ScriptableObjectEventListener<_structs.SForce2D[], SForce2DArraySoEvent, SForce2DArrayUnityEvent>
   {
   }
}