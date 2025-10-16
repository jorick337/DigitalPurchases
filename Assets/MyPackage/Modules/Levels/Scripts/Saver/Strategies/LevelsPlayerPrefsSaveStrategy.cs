using System.Linq;
using UnityEngine;

namespace MyPackage.Modules.Saver
{
    public partial class PlayerPrefsSaveStrategy : SaveStrategy
    {
        public void SaveStars(int[] value) => PlayerPrefs.SetString("LevelStars", string.Join(",", value));
        public void SaveTrophies(int value) => PlayerPrefs.SetInt("Trophies", value);
        public void SaveLevel(int value) => PlayerPrefs.SetInt("Level", value);

        public int[] LoadStars()
        {
            string saved = PlayerPrefs.GetString("LevelStars", string.Join(",", Enumerable.Repeat("0", SaveManager.MaxLevel)));

            return saved.Split(',').Select(int.Parse).ToArray();
        }

        public int LoadTrophies() => PlayerPrefs.GetInt("Trophies", 0);
        public int LoadLevel() => PlayerPrefs.GetInt("Level", 0);
    }
}