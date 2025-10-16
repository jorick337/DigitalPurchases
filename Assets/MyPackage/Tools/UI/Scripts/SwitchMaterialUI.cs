using UnityEngine;
using UnityEngine.UI;

namespace MyPackage.Tools.UI
{
    public class SwitchMaterialUI : MonoBehaviour
    {
        [SerializeField] private Graphic _graphic;
        [SerializeField] private Material _firstMaterial;
        [SerializeField] private Material _secondMaterial;

        public void Switch(bool active) => _graphic.material = active ? _firstMaterial : _secondMaterial;
    }
}