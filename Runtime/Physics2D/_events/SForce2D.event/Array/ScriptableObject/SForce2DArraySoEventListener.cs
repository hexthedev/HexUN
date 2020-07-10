using TobiasUN.Core.Events;
using UnityEngine;
using UnityEngine.Events;

namespace TobiasUN.Core.Physics2D
{
   [AddComponentMenu("TobiasUN/Physics2D/Events/SForce2DArray/SForce2DArraySoEventListener")]
   public class SForce2DArraySoEventListener : ScriptableObjectEventListener<SForce2D[], SForce2DArraySoEvent, SForce2DArrayUnityEvent>
   {
   }
}