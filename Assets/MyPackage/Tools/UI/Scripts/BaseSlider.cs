using UnityEngine;
using UnityEngine.UI;

namespace MyPackage.Tools.UI
{
    public class BaseSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void SetValue(int value) => _slider.value = value;
        public void SetValue(float value) => _slider.value = value;
    }
}