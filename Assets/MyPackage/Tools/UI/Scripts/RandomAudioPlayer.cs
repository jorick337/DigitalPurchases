using System.Collections;
using UnityEngine;

namespace MyPackage.Tools.UI
{
    public class RandomAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _audioClips;
        [SerializeField] private float _fadeDuration = 0f;

        public void PlayRandom()
        {
            if (_audioClips == null || _audioClips.Length == 0) return;

            int random = Random.Range(0, _audioClips.Length);
            AudioClip newClip = _audioClips[random];

            StartCoroutine(FadeToNewClip(newClip));
        }

        private IEnumerator FadeToNewClip(AudioClip newClip)
        {
            float volume = _audioSource.volume;

            yield return StartCoroutine(Fade(volume, 0));

            _audioSource.clip = newClip;
            _audioSource.Play();

            yield return StartCoroutine(Fade(0, volume));

            _audioSource.volume = volume;
        }

        private IEnumerator Fade(float startVolume, float endVolume)
        {
            float time = 0f;

            while (time < _fadeDuration)
            {
                time += Time.deltaTime;
                _audioSource.volume = Mathf.Lerp(startVolume, endVolume, time / _fadeDuration);
                yield return null;
            }
        }
    }
}