using HexCS.Core;

using Event = HexCS.Core.Event;

namespace HexUN.CSStandard.StateMachine
{
    /// <summary>
    /// A state is a single state that operates over an environment.
    /// Ticking the state provides some input that is used by the state
    /// to attempt to move to a new state, or remain in current state
    /// </summary>
    public abstract class AState<TStatesEnum, TEnvrionment>
    {
        // --- COMMENTED OUT CAUSE I DONT AGREE WITH MY CODE, WILL IT BREAK SOMETHING? ---
        //private Event _onChangeState = new Event();

        ///// <summary>
        ///// Emited when the state has changed
        ///// </summary>
        //public IEventSubscriber OnChangeState => _onChangeState;

        /// <summary>
        /// Is the state initialized
        /// </summary>
        public bool IsInitialized { get; private set; } = false;

        /// <summary>
        /// Initialize the state if it is not already initialized. Returns true if
        /// after state initalization the nextState should be moved to. Careful, there
        /// is room for infinite loops here, if Initialization always moves to
        /// the next state and next state is it self. 
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

        /// <summary>
        /// Tick the state. Returns true if the state is completed, and provides the next state that should occur
        /// </summary>
        /// <param name="env"></param>
        /// <param name="args"></param>
        /// <param name="nextState"></param>
        /// <returns></returns>
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