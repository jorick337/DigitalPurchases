using UnityEngine;

namespace MyPackage.Modules.Saver
{
    public partial class PlayerPrefsSaveStrategy : SaveStrategy
    {
        public int LoadMoney() => PlayerPrefs.GetInt("Money", 0);
        public void SaveMoney(int money) => PlayerPrefs.SetInt("Money", money);

        public int LoadRecord() => PlayerPrefs.GetInt("Record", 0);
        public void SaveRecord(int record) => PlayerPrefs.SetInt("Record", record);

        public int LoadLastRecord() => PlayerPrefs.GetInt("LastRecord", 0);
        public void SaveLastRecord(int record) => PlayerPrefs.SetInt("LastRecord", record);
    }
}