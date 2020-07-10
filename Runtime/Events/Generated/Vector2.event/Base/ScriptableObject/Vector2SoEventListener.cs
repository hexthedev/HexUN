using UnityEngine;
using UnityEngine.Events;

namespace HexUN.Events
{
   [AddComponentMenu("HexUN/Core/Events/Vector2/Vector2SoEventListener")]
   public class Vector2SoEventListener : ScriptableObjectEventListener<Vector2, Vector2SoEvent, Vector2UnityEvent>
   {
   }
}