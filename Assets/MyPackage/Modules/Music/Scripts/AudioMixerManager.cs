using UnityEngine;
using UnityEngine.Audio;

namespace MyPackage.Modules.Musics
{
    public enum TypeMixerGroup
    {
        Main,
        Sounds,
        Music,
    }

    public class AudioMixerManager : MonoBehaviour
    {
        public static AudioMixerManager Instance { get; private set; }

        [SerializeField] private AudioMixerGroup _mainAudioMixerGroup;
        [SerializeField] private AudioMixerGroup _soundsAudioMixerGroup;
        [SerializeField] private AudioMixerGroup _musicAudioMixerGroup;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public AudioMixerGroup GetAudioMixerGroupByType(TypeMixerGroup typeMixerGroup)
        {
            switch (typeMixerGroup)
            {
                case TypeMixerGroup.Main: return _mainAudioMixerGroup;
                case TypeMixerGroup.Sounds: return _soundsAudioMixerGroup;
                case TypeMixerGroup.Music: return _musicAudioMixerGroup;
                default: return _mainAudioMixerGroup;
            }
        }
    }
}