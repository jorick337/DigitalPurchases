namespace MyPackage.Modules.Saver
{
    public partial class SaveManager
    {
        public static bool LoadMusicActive() => _strategy.LoadMusicActive();
        public static void SaveMusicActive(bool active) => _strategy.SaveMusicActive(active);

        public static bool LoadSoundsActive() => _strategy.LoadSoundsActive();
        public static void SaveSoundsActive(bool active) => _strategy.SaveSoundsActive(active);

        public static float LoadMusicVolume() => _strategy.LoadMusicVolume();
        public static void SaveMusicVolume(float value) => _strategy.SaveMusicVolume(value);

        public static float LoadSoundsVolume() => _strategy.LoadSoundsVolume();
        public static void SaveSoundsVolume(float value) => _strategy.SaveSoundsVolume(value);
    }
}