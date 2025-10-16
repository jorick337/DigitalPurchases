namespace MyPackage.Modules.Saver
{
    public partial class SaveManager
    {
        public static int LoadMoney() => _strategy.LoadMoney();
        public static void SaveMoney(int money) => _strategy.SaveMoney(money);

        public static int LoadRecord() => _strategy.LoadRecord();
        public static void SaveRecord(int record) => _strategy.SaveRecord(record);

        public static int LoadLastRecord() => _strategy.LoadLastRecord();
        public static void SaveLastRecord(int record) => _strategy.SaveLastRecord(record);
    }
}