using MyPackage.Modules.Saver;
using UnityEngine;

namespace MyPackage.Modules.PlayerSystem
{
    public class PlayerSetValues : MonoBehaviour
    {
        private PlayerManager _playerManager;

        private void Start() => _playerManager = PlayerManager.Instance;

        public void SaveLastRecord() => SaveManager.SaveLastRecord(_playerManager.LastRecord.Value);

        public void AddMoney(int value) => _playerManager.AddMoney(value);

        public void SetRecord(int value) => _playerManager.SetRecord(value);
        public void SetLastRecord(int value) => _playerManager.LastRecord.Value = value;
    }
}