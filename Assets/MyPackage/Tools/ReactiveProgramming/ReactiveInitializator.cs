using UnityEngine;
using UnityEngine.Events;

namespace MyPackage.Tools.ReactiveProgramming
{
    public class ReactiveInitializator<T> : MonoBehaviour
    {
        [SerializeField] private UnityEvent<ReactiveVariable<T>> _onVariableCreated;
        [SerializeField] private UnityEvent<T> _onInitialValueSet;
        [SerializeField] private UnityEvent<T> _onValueChanged;

        protected ReactiveVariable<T> _reactiveVariable;

        protected void Start() => Init();
        protected void OnDestroy() => _reactiveVariable.Changed -= InvokeOnValueChanged;

        public virtual void Init()
        {
            InvokeOnVariableCreated();
            InvokeOnInitialValueSet();
            _reactiveVariable.Changed += InvokeOnValueChanged;
        }

        protected void InvokeOnVariableCreated() => _onVariableCreated?.Invoke(_reactiveVariable);
        protected void InvokeOnInitialValueSet() => _onInitialValueSet?.Invoke(_reactiveVariable.Value);
        protected void InvokeOnValueChanged(T oldValue, T newValue) => _onValueChanged?.Invoke(newValue);
    }
}