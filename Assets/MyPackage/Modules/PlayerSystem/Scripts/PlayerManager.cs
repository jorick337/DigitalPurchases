using System.Collections;
using MyPackage.Modules.Init;
using MyPackage.Modules.Saver;
using MyPackage.Tools.ReactiveProgramming;

namespace MyPackage.Modules.PlayerSystem
{
    public class PlayerManager : Manager
    {
        public static PlayerManager Instance { get; private set; }

        public ReactiveVariable<int> Money { get; private set; } = new();
        public ReactiveVariable<int> Record { get; private set; } = new();
        public ReactiveVariable<int> LastRecord { get; private set; } = new();

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void OnDestroy()
        {
            Money.Changed -= OnMoneyChange;
            Record.Changed -= OnRecordChange;
            LastRecord.Changed -= OnLastRecordChange;
        }

        public override IEnumerator Init()
        {
            Money.Value = SaveManager.LoadMoney();
            Record.Value = SaveManager.LoadRecord();
            LastRecord.Value = SaveManager.LoadLastRecord();

            Money.Changed += OnMoneyChange;
            Record.Changed += OnRecordChange;
            LastRecord.Changed += OnLastRecordChange;

            yield return base.Init();
        }

        public bool AddMoney(int money)
        {
            if (Money.Value + money >= 0)
            {
                Money.Value += money;
                return true;
            }

            return false;
        }

        public void SetRecord(int value)
        {
            if (value > Record.Value)
                Record.Value = value;
        }

        private void OnRecordChange(int oldValue, int newValue) => SaveManager.SaveRecord(newValue);
        private void OnLastRecordChange(int oldValue, int newValue) => SetRecord(newValue);
        private void OnMoneyChange(int oldValue, int newValue) => SaveManager.SaveMoney(newValue);
    }
}