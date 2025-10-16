using UnityEngine;

namespace MyPackage.Modules.Levels.Loader
{
    public class LevelLoader : MonoBehaviour
    {
        public static LevelLoader Instance { get; private set; }

        private LevelProvider _levelProvider;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                _levelProvider = new();
            }
        }

        public async void Load() => await Instance._levelProvider.LoadAsync(LevelsManager.Instance.Level.Value);
        public async void Unload() => await Instance._levelProvider.UnloadAllAsync();
    }
}