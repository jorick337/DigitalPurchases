using UnityEngine;

namespace MyPackage.Tools.UI
{
    public class Destroyer : MonoBehaviour
    {
        public void DestroySelf() => Destroy(gameObject);
        public void DestroyTarget(GameObject target) => Destroy(target);
    }
}

