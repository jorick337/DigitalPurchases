using UnityEngine;

namespace MyPackage.Modules.Levels.Values
{
    public class LevelSetValues : MonoBehaviour
    {
        private LevelsManager _levelsManager;

        private void Start() => _levelsManager = LevelsManager.Instance;

        public void AddLevel() => _levelsManager.Level.Value++;
    }
}