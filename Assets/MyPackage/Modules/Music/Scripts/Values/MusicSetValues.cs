using UnityEngine;

namespace MyPackage.Modules.Musics
{
    public class MusicSetValues : MonoBehaviour
    {
        private MusicManager _musicManager;

        private void Start() => _musicManager = MusicManager.Instance;

        public void SetMusicVolume(float value) => _musicManager.MusicVolume.Value = value;
        public void SetSoundsVolume(float value) => _musicManager.SoundsVolume.Value = value;

        public void SetIsMusicActive(bool active) => _musicManager.IsMusicActive.Value = active;
        public void SetIsSoundsActive(bool active) => _musicManager.IsSoundsActive.Value = active;
    }
}