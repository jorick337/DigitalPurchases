using System.Collections;

namespace MyPackage.Modules.Init
{
    public abstract class StrategyInitManagers
    {
        public abstract IEnumerator Init(Manager[] managers);
    }
}