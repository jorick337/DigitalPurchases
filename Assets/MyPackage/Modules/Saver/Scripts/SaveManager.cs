namespace MyPackage.Modules.Saver
{
    public enum TypeStrategyInitManagers
    {
        Simple,
        YG2,
    }

    public partial class SaveManager
    {
        private static SaveStrategy _strategy;

        public static void Init(TypeStrategyInitManagers strategy)
        {
            switch (strategy)
            {
                case TypeStrategyInitManagers.Simple:
                    _strategy = new PlayerPrefsSaveStrategy();
                    break;
                //case TypeStrategyInitManagers.YG2:
                //    _strategy = new YGSaveStrategy();
                    break;
                default:
                    break;
            }
        }
    }
}