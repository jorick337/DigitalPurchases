using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyPackage.Tools.UI
{
    public class BaseText : MonoBehaviour
    {
        [SerializeField] private Text _uiText;
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        private bool _useTMP;

        private void Awake() => _useTMP = _uiText == null;

        public void SetText(string text)
        {
            if (_useTMP)
                _textMeshPro.text = text;
            else
                _uiText.text = text;
        }

        public void AddText(string text)
        {
            if (_useTMP)
                _textMeshPro.text += text;
            else
                _uiText.text += text;
        }

        public void SetText(int text) => SetText(text.ToString());
        public void AddText(int text) => AddText(text.ToString());
    }
}