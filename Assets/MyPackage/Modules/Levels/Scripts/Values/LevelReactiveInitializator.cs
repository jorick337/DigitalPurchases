using MyPackage.Tools.ReactiveProgramming;

namespace MyPackage.Modules.Levels.Values
{
    public class LevelReactiveInitializator : ReactiveInitializator<int>
    {
        public override void Init()
        {
            _reactiveVariable = LevelsManager.Instance.Level;

            base.Init();
        }
    }
}