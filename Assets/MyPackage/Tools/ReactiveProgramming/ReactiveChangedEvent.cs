using UnityEngine;
using UnityEngine.Events;

namespace MyPackage.Tools.ReactiveProgramming
{
    public class ReactiveChangedEvent<T> : MonoBehaviour
    {
        [System.Serializable] public class ValueChangedEvent : UnityEvent<T, T> { }
        [System.Serializable] public class NewValueChangedEvent : UnityEvent<T> { }
        [System.Serializable] public class OldValueChangedEvent : UnityEvent<T> { }

        [SerializeField] private ValueChangedEvent _onValueChangedActions = new();
        [SerializeField] private NewValueChangedEvent _onNewValueChangedActions = new();
        [SerializeField] private OldValueChangedEvent _onOldValueChangedActions = new();

        private ReactiveVariable<T> _reactiveVariable;

        private void OnDisable()
        {
            if (_reactiveVariable != null)
                _reactiveVariable.Changed -= InvokeActions;
        }

        public void SetReactiveVariable(ReactiveVariable<T> variable)
        {
            _reactiveVariable = variable;
            _reactiveVariable.Changed += InvokeActions;
        }

        private void InvokeActions(T oldValue, T newValue)
        {
            _onValueChangedActions?.Invoke(oldValue, newValue);
            _onNewValueChangedActions?.Invoke(newValue);
            _onOldValueChangedActions?.Invoke(oldValue);
        }
    }
}