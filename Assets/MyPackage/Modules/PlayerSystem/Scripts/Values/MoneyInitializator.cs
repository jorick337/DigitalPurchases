using MyPackage.Tools.ReactiveProgramming;

namespace MyPackage.Modules.PlayerSystem
{
    public class MoneyInitializator : ReactiveInitializator<int>
    {
        private PlayerManager _playerManager;

        public override void Init()
        {
            _playerManager = PlayerManager.Instance;
            _reactiveVariable = _playerManager.Money;

            base.Init();
        }
    }
}