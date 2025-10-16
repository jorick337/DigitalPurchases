using System.Collections;
using MyPackage.Modules.Init;
using MyPackage.Modules.Saver;
using MyPackage.Tools.ReactiveProgramming;

namespace MyPackage.Modules.Levels
{
    public class LevelsManager : Manager
    {
        public static LevelsManager Instance { get; private set; }

        public ReactiveVariable<int[]> Stars { get; private set; } = new();
        public ReactiveVariable<int> Trophies { get; private set; } = new();
        public ReactiveVariable<int> Level { get; private set; } = new();

        // private GameLevelsProvider _gameLevelsProvider = new();

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void OnDestroy()
        {
            Stars.Changed -= OnStarsChange;
            Trophies.Changed -= OnTrophiesChange;
            Level.Changed -= OnLevelChange;
        }

        public override IEnumerator Init()
        {
            Stars.Value = SaveManager.LoadStars();
            Trophies.Value = SaveManager.LoadTrophies();
            Level.Value = SaveManager.LoadLevel();

            Stars.Changed += OnStarsChange;
            Trophies.Changed += OnTrophiesChange;
            Level.Changed += OnLevelChange;

            return base.Init();
        }

        // public void AddStars(int stars)
        // {
        //     if (Stars[ChosedNumberLevel - 1] >= stars)
        //         return;

        //     Stars[ChosedNumberLevel - 1] = stars;
        // }

        // public void AddTrophy(int trophy)
        // {
        //     Trophies += trophy;
        // }

        // public void AddLevel()
        // {
        //     if (ChosedNumberLevel + 1 <= Stars.Length)
        //         ChosedNumberLevel += 1;
        // }

        // public int GetStars()
        // {
        //     int number = 0;
        //     for (int i = 0; i < Stars.Length; i++)
        //         number += Stars[i];
        //     return number;
        // }

        // public bool IsChosedNumberLevelMaximum() => ChosedNumberLevel == Stars.Length;
        // public void SetLevel(int level) => ChosedNumberLevel = level;

        private void OnStarsChange(int[] oldValue, int[] newValue) => SaveManager.SaveStars(newValue);
        private void OnTrophiesChange(int oldValue, int newValue) => SaveManager.SaveTrophies(newValue);
        private void OnLevelChange(int oldValue, int newValue) => SaveManager.SaveLevel(newValue);
    }
}