using UnityEngine;

namespace Game.Play.Welcome
{
    public class WelcomeLoader : MonoBehaviour
    {
        public WelcomeLoader Instance { get; private set; }

        private WelcomeProvider _welcomeProvider = new();

        private void Awake() => Instance = this;

        public void Load(int level) => Instance._welcomeProvider.Load(level);
        public async void Unload() => await Instance._welcomeProvider.UnloadAllAsync();
    }
}

