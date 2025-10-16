using DG.Tweening;
using UnityEngine;

namespace MyPackage.Tools.UI.Animations
{
    public class AnimationRotate : YAnimation
    {
        [Header("Rotate")]
        [SerializeField] private Vector3 _visibleRotation;
        [SerializeField] private Vector3 _hiddenRotation;

        public override Sequence AnimationIn() => DOTween.Sequence().Append(transform.DORotate(_visibleRotation, _timeToShow));
        public override Sequence AnimationOut() => DOTween.Sequence().Append(transform.DORotate( _hiddenRotation, _timeToHide));
    }
}