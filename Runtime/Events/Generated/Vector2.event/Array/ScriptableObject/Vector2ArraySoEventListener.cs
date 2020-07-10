using UnityEngine;
using UnityEngine.Events;

namespace TobiasUN.Core.Events
{
   [AddComponentMenu("TobiasUN/Core/Events/Vector2Array/Vector2ArraySoEventListener")]
   public class Vector2ArraySoEventListener : ScriptableObjectEventListener<Vector2[], Vector2ArraySoEvent, Vector2ArrayUnityEvent>
   {
   }
}