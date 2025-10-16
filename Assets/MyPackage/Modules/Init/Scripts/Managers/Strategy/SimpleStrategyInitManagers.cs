using System.Collections;

namespace MyPackage.Modules.Init
{
    public class SimpleStrategyInitManagers : StrategyInitManagers
    {
        public override IEnumerator Init(Manager[] managers)
        {
            foreach (var manager in managers)
                yield return manager.Init();
        }
    }
}