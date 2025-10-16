using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace MyPackage.Tools.UI
{
    public class RepeaterEvent : MonoBehaviour
    {
        [SerializeField] private float trackDuration = 60f;
        [SerializeField] private UnityEvent _repeatEvent;

        private void Start() => StartCoroutine(InvokeAlways());

        IEnumerator InvokeAlways()
        {
            while (true)
            {
                yield return new WaitForSeconds(trackDuration);
                _repeatEvent?.Invoke();
            }
        }
    }
}