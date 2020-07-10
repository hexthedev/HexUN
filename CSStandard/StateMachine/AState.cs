using TobiasCSStandard.Core;

using Event = TobiasCSStandard.Core.Event;

namespace TobiasUN.CSStandard.StateMachine
{
    /// <summary>
    /// A state is a single state that operates over an environment.
    /// Ticking the state provides some input that is used by the state
    /// to attempt to move to a new state, or remain in current state
    /// </summary>
    public abstract class AState<TStatesEnum, TEnvrionment>
    {
        private Event _onChangeState = new Event();

        /// <summary>
        /// Emited when the state has changed
        /// </summary>
        public IEventSubscriber OnChangeState => _onChangeState;

        /// <summary>
        /// Is the state initialized
        /// </summary>
        public bool IsInitialized { get; private set; } = false;

        /// <summary>
        /// Initialize the state if it is not already initialized
        /// </summary>
        public bool IntializeState(TEnvrionment env, out TStatesEnum nextState)
        {
            if (IsInitialized)
            {
                nextState = default;
                return false;
            }

            IsInitialized = true;
            return Initialize(env, out nextState);
        }

        /// <summary>
        /// Clears the state, meaning that the state will require
        /// reinitalization to be used again
        /// </summary>
        public void ClearState()
        {
            if (!IsInitialized) return;
            Clear();
            IsInitialized = false;
        }

        public abstract bool Tick(TEnvrionment env, object args, out TStatesEnum nextState);


        /// <summary>
        /// When first entering this state, perform actions on environement
        /// required to initalize the state
        /// </summary>
        protected abstract bool Initialize(TEnvrionment env, out TStatesEnum nextState);

        /// <summary>
        /// How to clear the state so that it required reinitalization
        /// </summary>
        protected abstract void Clear();
    }
}