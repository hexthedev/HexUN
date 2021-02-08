using HexCS.Core;

using Event = HexCS.Core.Event;

namespace HexUN.MonoB
{
    /// <summary>
    /// Global access point for Unity Engine functions that can be accessed
    /// statically. This can allow devs to register funcitons ot main thread, for example
    /// </summary>
    public class MonoCallbacks : AMonoSingletonPersistent<MonoCallbacks>
    {
        private Event _OnUpdate = new Event();

        private Event _OnLateUpdate = new Event();

        private Event _OnFixedUpdate = new Event();

        #region API
        /// <summary>
        /// Subscriber for Update functions
        /// </summary>
        public IEventSubscriber OnUpdate => _OnUpdate;

        /// <summary>
        /// Subscriber for LateUpdate functions
        /// </summary>
        public IEventSubscriber OnLateUpdate => _OnLateUpdate;

        /// <summary>
        /// Subscriber for fixed update functions
        /// </summary>
        public IEventSubscriber OnFixedUpdate => _OnFixedUpdate;
        #endregion

        private void Update()
        {
            _OnUpdate.Invoke();
        }

        private void LateUpdate()
        {
            _OnLateUpdate.Invoke();
        }

        private void FixedUpdate()
        {
            _OnFixedUpdate.Invoke();
        }
    }
}