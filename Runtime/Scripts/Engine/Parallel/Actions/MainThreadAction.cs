using System;
using HexUN.MonoB;

namespace HexUN.Parallel
{
    /// <summary>
    /// When perform is called, registers action to be performed ASAP on main thread
    /// </summary>
    public class MainThreadAction
    {
        private Action _action;

        #region API
        public MainThreadAction(Action action)
        {
            _action = action;
        }

        public void Call()
        {
            NGMonoCallbacks.Instance.OnUpdate.SubscribeSingleUse(_action);
        }
        #endregion
    }

    /// <summary>
    /// When perform is called, registers action to be performed ASAP on main thread
    /// </summary>
    public class MainThreadAction<T>
    {
        private Action<T> _action;

        #region API
        public MainThreadAction(Action<T> action)
        {
            _action = action;
        }

        public void Call(T input)
        {
            NGMonoCallbacks.Instance.OnUpdate.SubscribeSingleUse(() => _action(input));
        }
        #endregion
    }
}