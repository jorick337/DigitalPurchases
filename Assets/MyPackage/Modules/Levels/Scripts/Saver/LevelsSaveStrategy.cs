namespace MyPackage.Modules.Saver
{
    public partial interface SaveStrategy
    {
        void SaveStars(int[] value);
        int[] LoadStars();

        void SaveTrophies(int value);
        int LoadTrophies();

        void SaveLevel(int value);
        int LoadLevel();
    }
}