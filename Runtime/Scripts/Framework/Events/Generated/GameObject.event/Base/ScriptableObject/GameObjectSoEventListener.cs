using Hex.UN.Runtime.Framework.Events.Generated.GameObject.@event.Base.Generic;
using UnityEngine;

namespace Hex.UN.Runtime.Framework.Events.Generated.GameObject.@event.Base.ScriptableObject
{
   [AddComponentMenu("HexUN/Events/GameObject/GameObjectSoEventListener")]
   public class GameObjectSoEventListener : ScriptableObjectEventListener<UnityEngine.GameObject, GameObjectSoEvent, GameObjectUnityEvent>
   {
   }
}