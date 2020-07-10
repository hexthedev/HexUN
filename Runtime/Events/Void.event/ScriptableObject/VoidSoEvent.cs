using UnityEngine;
using TobiasCSStandard.Core;
using Event = TobiasCSStandard.Core.Event;

namespace HexUN.Events
{
   [CreateAssetMenu(fileName = "VoidEvent", menuName = "HexUN/Core/Events/Void")]
   public class VoidSoEvent : ScriptableObject
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