using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace MyPackage.Modules.Init
{
    public class InitEvents : MonoBehaviour
    {
        [SerializeField] private float _interval = 0f;
        [SerializeField] private bool _canStart = false;
        [SerializeField] private UnityEvent[] _events;

        private void Start()
        {
            if (_canStart) Init();
        }

        public void Init() => StartCoroutine(InvokeSequentially());

        private IEnumerator InvokeSequentially()
        {
            foreach (var eventItem in _events)
            {
                eventItem?.Invoke();
                yield return new WaitForSeconds(_interval);
            }
        }
    }
}