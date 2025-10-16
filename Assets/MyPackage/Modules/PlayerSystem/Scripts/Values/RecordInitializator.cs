using MyPackage.Tools.ReactiveProgramming;
using UnityEngine;

namespace MyPackage.Modules.PlayerSystem
{
    public class RecordInitializator : ReactiveInitializator<int>
    {
        [SerializeField] private bool _isCurrentRecord;

        private PlayerManager _playerManager;

        public override void Init()
        {
            _playerManager = PlayerManager.Instance;
            _reactiveVariable = _isCurrentRecord ? _playerManager.LastRecord : _playerManager.Record;

            base.Init();
        }
    }
}