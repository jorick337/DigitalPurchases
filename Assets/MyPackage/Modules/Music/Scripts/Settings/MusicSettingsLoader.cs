using UnityEngine;

namespace MyPackage.Modules.Musics
{
    public class MusicSettingsLoader : MonoBehaviour
    {
        public static MusicSettingsLoader Instance;

        private MusicSettingsProvider _musicSettingsProvider;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                _musicSettingsProvider = new();
            }
        }

        public async void Load() => await Instance._musicSettingsProvider.LoadAsync(); 
        public async void Unload() => await Instance._musicSettingsProvider.UnloadAllAsync();
    }
}