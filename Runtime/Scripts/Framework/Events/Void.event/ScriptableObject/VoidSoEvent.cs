using HexCS.Core;
using UnityEngine;
using Event = HexCS.Core.Event;

namespace Hex.UN.Runtime.Framework.Events.Void.@event.ScriptableObject
{
   [CreateAssetMenu(fileName = "VoidEvent", menuName = "HexUN/Events/Void")]
   public class VoidSoEvent : UnityEngine.ScriptableObject
    {
        private Event _event = new Event();

        #region API
        /// <summary>
        /// Get the event subscriber that allows you to subscribe actions
        /// directly to event from code
        /// </summary>
        public IEventSubscriber Event => _event;

        /// <summary>
        /// Invoke the event
        /// </summary>
        /// <param name="args"></param>
        public void Invoke()
        {
            _event.Invoke();
        }
        #endregion
    }
}