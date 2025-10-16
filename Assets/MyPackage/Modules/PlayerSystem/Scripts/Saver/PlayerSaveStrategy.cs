namespace MyPackage.Modules.Saver
{
    public partial interface SaveStrategy
    {
        void SaveMoney(int money);
        int LoadMoney();

        void SaveRecord(int record);
        int LoadRecord();

        void SaveLastRecord(int record);
        int LoadLastRecord();
    }
}