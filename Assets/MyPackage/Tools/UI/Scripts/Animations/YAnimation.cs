using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace MyPackage.Tools.UI.Animations
{
    public abstract class YAnimation : MonoBehaviour
    {
        #region CORE

        [Header("Core")]
        [SerializeField] protected float _timeToShow;
        [SerializeField] protected float _timeToHide;
        [SerializeField] protected bool _isLooping = false;

        private Sequence _animationIn;
        private Sequence _animationOut;
        private Sequence _animation;

        private CancellationToken _destroyToken;
        private CancellationTokenSource _loopCts;

        #endregion

        #region MONO

        protected virtual void Awake() => _destroyToken = this.GetCancellationTokenOnDestroy();

        private void Start()
        {
            if (_isLooping)
                StartAlwaysAnimation();
        }

        private void OnDisable() => KillAnimations();
        private void OnDestroy() => KillAnimations();

        #endregion

        #region ANIMATIONS

        public virtual Sequence AnimationIn() => DOTween.Sequence();
        public virtual Sequence AnimationOut() => DOTween.Sequence();

        #endregion

        #region ANIMATE ONCE

        public void AnimateIn()
        {
            if (!IsValid()) return;

            _animationIn?.Kill();
            _animationIn = AnimationIn()?.SetTarget(this);
        }

        public void AnimateOut()
        {
            if (!IsValid()) return;

            _animationOut?.Kill();
            _animationOut = AnimationOut()?.SetTarget(this);
        }

        public void Animate()
        {
            if (!IsValid()) return;

            _animation?.Kill();
            _animation = DOTween.Sequence()
                .Append(AnimationIn()?.SetTarget(this))
                .Append(AnimationOut()?.SetTarget(this));
        }

        #endregion

        #region ANIMATE ASYNC

        public async UniTask AnimateInAsync()
        {
            if (!IsValid()) return;

            AnimateIn();

            if (_animationIn != null)
                await _animationIn.AsyncWaitForCompletion();
        }

        public async UniTask AnimateOutAsync()
        {
            if (!IsValid()) return;

            AnimateOut();

            if (_animationOut != null)
                await _animationOut.AsyncWaitForCompletion();
        }

        public async UniTask AnimateAsync()
        {
            if (!IsValid()) return;

            await AnimateInAsync();
            await AnimateOutAsync();
        }

        #endregion

        #region ANIMATE ALWAYS (LOOPING)

        public void StartAlwaysAnimation()
        {
            StopAlwaysAnimation(); // на случай если уже запущено

            _loopCts = new CancellationTokenSource();
            AnimateAlways(_loopCts.Token).Forget();
        }

        public void StopAlwaysAnimation()
        {
            if (_loopCts == null) return;

            _loopCts.Cancel();
            _loopCts.Dispose();
            _loopCts = null;
        }

        private async UniTaskVoid AnimateAlways(CancellationToken externalToken)
        {
            var linkedToken = CancellationTokenSource.CreateLinkedTokenSource(_destroyToken, externalToken).Token;

            try
            {
                while (!linkedToken.IsCancellationRequested && IsValid())
                {
                    await AnimateAsync().AttachExternalCancellation(linkedToken);
                }
            }
            catch (OperationCanceledException) { }

            AnimateIn();
        }

        #endregion

        private void KillAnimations()
        {
            StopAlwaysAnimation();
            _animationIn?.Kill();
            _animationOut?.Kill();
            _animation?.Kill();
            DOTween.Kill(this);
        }

        private bool IsValid() => isActiveAndEnabled;
    }
}