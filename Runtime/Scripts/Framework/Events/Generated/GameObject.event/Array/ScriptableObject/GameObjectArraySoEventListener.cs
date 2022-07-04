using Hex.UN.Runtime.Framework.Events.Generated.GameObject.@event.Array.Generic;
using UnityEngine;

namespace Hex.UN.Runtime.Framework.Events.Generated.GameObject.@event.Array.ScriptableObject
{
   [AddComponentMenu("HexUN/Events/GameObjectArray/GameObjectArraySoEventListener")]
   public class GameObjectArraySoEventListener : ScriptableObjectEventListener<UnityEngine.GameObject[], GameObjectArraySoEvent, GameObjectArrayUnityEvent>
   {
   }
}