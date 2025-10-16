using MyPackage.Modules.Saver;
using UnityEngine;

namespace MyPackage.Modules.Init
{
    public class InitManagers : MonoBehaviour
    {
        public static InitManagers Instance { get; private set; }

        [SerializeField] private TypeStrategyInitManagers _typeStrategyInitManagers;
        [SerializeField] private Manager[] _managers;

        private StrategyInitManagers _initManagersStrategy;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                
                SaveManager.Init(_typeStrategyInitManagers);
                InitStrategy();
                
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }

        private void InitStrategy()
        {
            switch (_typeStrategyInitManagers)
            {
                case TypeStrategyInitManagers.Simple:
                    _initManagersStrategy = new SimpleStrategyInitManagers();
                    break;
                //case TypeStrategyInitManagers.YG2:
                //    _initManagersStrategy = new YG2StrategyInitManagers();
                    break;
                default:
                    break;
            }
        }

        public void StartCoroutineInit() => StartCoroutine(_initManagersStrategy.Init(_managers));
    }
}