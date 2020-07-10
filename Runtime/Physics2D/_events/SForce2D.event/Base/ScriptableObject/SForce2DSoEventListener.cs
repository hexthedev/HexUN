using TobiasUN.Core.Events;
using UnityEngine;
using UnityEngine.Events;

namespace TobiasUN.Core.Physics2D
{
   [AddComponentMenu("TobiasUN/Physics2D/Events/SForce2D/SForce2DSoEventListener")]
   public class SForce2DSoEventListener : ScriptableObjectEventListener<SForce2D, SForce2DSoEvent, SForce2DUnityEvent>
   {
   }
}