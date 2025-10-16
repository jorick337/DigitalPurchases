namespace MyPackage.Modules.Saver
{
    public partial class SaveManager
    {
        public const int MaxLevel = 1;

        public static int[] LoadStars() => _strategy.LoadStars();
        public static void SaveStars(int[] value) => _strategy.SaveStars(value);

        public static int LoadTrophies() => _strategy.LoadTrophies();
        public static void SaveTrophies(int value) => _strategy.SaveTrophies(value);

        public static void SaveLevel(int value) => _strategy.SaveLevel(value);
        public static int LoadLevel() => _strategy.LoadLevel();
    }
}