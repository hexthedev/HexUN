using System;

namespace HexUN.Utilities
{
    /// <summary>
    /// Holds a variable. This variable can be set externally.
    /// Whenever the variable is set, a function is called on it
    /// </summary>
    public class OnChangeVariable<T> where T : UnityEngine.Object
    {
        private Action<T> _changeAction;

        private T _value;
        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                _changeAction(_value);
            }
        }

        public OnChangeVariable(Action<T> changeAction)
        {
            _changeAction = changeAction;
        }
    }
}