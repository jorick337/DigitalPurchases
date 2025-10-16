using DG.Tweening;
using UnityEngine;

namespace MyPackage.Tools.UI.Animations
{
    public class AnimationScale : YAnimation
    {
        [Header("Scale")]
        [SerializeField] private Vector3 _visibleScale;
        [SerializeField] private Vector3 _hiddenScale;

        public override Sequence AnimationIn() => DOTween.Sequence().Append(transform.DOScale(_visibleScale, _timeToShow));
        public override Sequence AnimationOut() => DOTween.Sequence().Append(transform.DOScale(_hiddenScale, _timeToHide));
    }
}