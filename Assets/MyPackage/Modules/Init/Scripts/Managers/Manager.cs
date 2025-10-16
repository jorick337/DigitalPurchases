using System.Collections;
using UnityEngine;

namespace MyPackage.Modules.Init
{
    public class Manager : MonoBehaviour
    {
        public virtual IEnumerator Init()
        {
            yield break;
        }

        public void StartCoroutineInit() => StartCoroutine(Init());
    }
}