using TobiasCSStandard.Core;

using Event = TobiasCSStandard.Core.Event;

namespace TobiasUN.Core.MonoB
{
    /// <summary>
    /// Global access point for Unity Engine functions that can be accessed
    /// statically. This can allow devs to register funcitons ot main thread, for example
    /// </summary>
    public class MonoCallbacks : AMonoSingletonPersistent<MonoCallbacks>
    {
        private Event _OnUpdate = new Event();

        private Event _OnFixedUpdate = new Event();

        #region API
        /// <summary>
        /// Subscriber for Update functions
        /// </summary>
        public IEventSubscriber OnUpdate => _OnUpdate;

        /// <summary>
        /// Subscriber for fixed update functions
        /// </summary>
        public IEventSubscriber OnFixedUpdate => _OnFixedUpdate;
        #endregion

        private void Update()
        {
            _OnUpdate.Invoke();
        }

        private void FixedUpdate()
        {
            _OnFixedUpdate.Invoke();
        }
    }
}