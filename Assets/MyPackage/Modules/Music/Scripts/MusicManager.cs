using System.Collections;
using MyPackage.Modules.Init;
using MyPackage.Modules.Saver;
using MyPackage.Tools.ReactiveProgramming;
using UnityEngine;
using UnityEngine.Audio;

namespace MyPackage.Modules.Musics
{
    public class MusicManager : Manager
    {
        public static MusicManager Instance { get; private set; }

        [SerializeField] private float _masterVolume = 1f;
        [SerializeField] private AudioMixer _mixer;

        public ReactiveVariable<bool> IsMusicActive { get; private set; } = new();
        public ReactiveVariable<bool> IsSoundsActive { get; private set; } = new();

        public ReactiveVariable<float> MusicVolume { get; private set; } = new();
        public ReactiveVariable<float> SoundsVolume { get; private set; } = new();

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void OnDestroy()
        {
            IsMusicActive.Changed -= OnMusicActiveChange;
            IsSoundsActive.Changed -= OnSoundsActiveChange;
            MusicVolume.Changed -= OnMusicVolumeChange;
            SoundsVolume.Changed -= OnSoundsVolumeChange;
        }

        private void Start() => UpdateMasterVolume();

        public override IEnumerator Init()
        {
            IsMusicActive.Value = SaveManager.LoadMusicActive();
            IsSoundsActive.Value = SaveManager.LoadSoundsActive();
            MusicVolume.Value = SaveManager.LoadMusicVolume();
            SoundsVolume.Value = SaveManager.LoadSoundsVolume();

            IsMusicActive.Changed += OnMusicActiveChange;
            IsSoundsActive.Changed += OnSoundsActiveChange;
            MusicVolume.Changed += OnMusicVolumeChange;
            SoundsVolume.Changed += OnSoundsVolumeChange;

            UpdateMusicVolume(IsMusicActive.Value);
            UpdateSoundsVolume(IsSoundsActive.Value);
            UpdateMusicVolume(MusicVolume.Value);
            UpdateSoundsVolume(SoundsVolume.Value);

            yield return base.Init();
        }

        private void OnMusicActiveChange(bool oldValue, bool newValue)
        {
            UpdateMusicVolume(newValue);
            SaveManager.SaveMusicActive(newValue);
        }

        private void OnSoundsActiveChange(bool oldValue, bool newValue)
        {
            UpdateSoundsVolume(newValue);
            SaveManager.SaveSoundsActive(newValue);
        }

        private void OnMusicVolumeChange(float oldValue, float newValue)
        {
            UpdateMusicVolume(newValue);
            SaveManager.SaveMusicVolume(newValue);
        }

        private void OnSoundsVolumeChange(float oldValue, float newValue)
        {
            UpdateSoundsVolume(newValue);
            SaveManager.SaveSoundsVolume(newValue);
        }

        private void UpdateMusicVolume(bool value) => SetMixerVolume("Music", value ? MusicVolume.Value : 0f);
        private void UpdateSoundsVolume(bool value) => SetMixerVolume("Sounds", value ? SoundsVolume.Value : 0f);

        private void UpdateMusicVolume(float value) => SetMixerVolume("Music", IsMusicActive.Value ? value : 0f);
        private void UpdateSoundsVolume(float value) => SetMixerVolume("Sounds", IsSoundsActive.Value ? value : 0f);

        private void UpdateMasterVolume() => SetMixerVolume("Master", _masterVolume);

        private void SetMixerVolume(string name, float volume) => _mixer.SetFloat(name, Mathf.Lerp(-80f, 0f, Mathf.Clamp01(volume)));
    }
}