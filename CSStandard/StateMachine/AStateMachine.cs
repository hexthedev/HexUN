using System;
using TobiasCSStandard.Core;

namespace HexUN.CSStandard.StateMachine
{
    /// <summary>
    /// A StateMachine is a simple class that maintains a reference to 
    /// the current state in a state machine flow. The state machine flow
    /// is represented by an enum, where the enum is the identity of a state.
    /// This is used to easily communicate with other systemss about the 
    /// current state and allows decoupling of the state from the implementation
    /// of the state.
    /// 
    /// It also emits events when important state changes occur.
    /// </summary>
    public abstract class AStateMachine<TStatesEnum, TEnvironment>
    {
        private EnumDicitonary<TStatesEnum, AState<TStatesEnum, TEnvironment>> _stateMapping;

        private AState<TStatesEnum, TEnvironment> _currentState;
        private EventBinding _onCurrentStateChangeBinding;

        private TEnvironment _environment;

        #region API
        /// <summary>
        /// Is the state machine initialized with a current state
        /// </summary>
        public bool IsInitalized { get; private set; } = false;

        /// <summary>
        /// The current state the machine is in
        /// </summary>
        public TStatesEnum CurrentState { get; private set; }

        /// <summary>
        /// Initalize the state machine. Will not initalize again if already initalized.
        /// This is where the environment and first state are provided
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="firstState"></param>
        public void Initalize(TEnvironment environment, EnumDicitonary<TStatesEnum, AState<TStatesEnum, TEnvironment>> states, TStatesEnum firstState)
        {
            if (IsInitalized) return;
            _environment = environment;
            _stateMapping = states;

            ChangeState(firstState);
            IsInitalized = true;
        }

        /// <summary>
        /// Tick the current state with the provided data
        /// </summary>
        /// <param name="data"></param>
        public void Tick(object data)
        {
            if (_currentState.Tick(_environment, data, out TStatesEnum state))
            {
                ChangeState(state);
            }
        }
        #endregion

        private void ChangeState(TStatesEnum state)
        {
            if(_onCurrentStateChangeBinding != null)
            {
                _onCurrentStateChangeBinding.UnSubscribe();
                _onCurrentStateChangeBinding = null;
            }

            _currentState = _stateMapping[state];
            if (_currentState == null) throw new ArgumentException("Attempting to change to a null state in state machine. This is not allowed.");

            _onCurrentStateChangeBinding = _currentState.OnChangeState.Subscribe(HandleOnChangeState);
            _currentState.ClearState();

            if(_currentState.IntializeState(_environment, out TStatesEnum nextState))
            {
                ChangeState(nextState);    
            }
            else
            {
                CurrentState = state;
            }

            void HandleOnChangeState() => ChangeState(state);
        }
    }
}