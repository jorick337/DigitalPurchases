using UnityEngine;

namespace MyPackage.Modules.Saver
{
    public partial class PlayerPrefsSaveStrategy : SaveStrategy
    {
        public bool LoadMusicActive() => PlayerPrefs.GetInt("MusicActive", 1) == 1;
        public void SaveMusicActive(bool active) => PlayerPrefs.SetInt("MusicActive", active ? 1 : 0);

        public bool LoadSoundsActive() => PlayerPrefs.GetInt("SoundsActive", 1) == 1;
        public void SaveSoundsActive(bool active) => PlayerPrefs.SetInt("SoundsActive", active ? 1 : 0);

        public float LoadMusicVolume() => PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        public void SaveMusicVolume(float value) => PlayerPrefs.SetFloat("MusicVolume", value);

        public float LoadSoundsVolume() => PlayerPrefs.GetFloat("SoundsVolume", 0.5f);
        public void SaveSoundsVolume(float value) => PlayerPrefs.SetFloat("SoundsVolume", value);
    }
}