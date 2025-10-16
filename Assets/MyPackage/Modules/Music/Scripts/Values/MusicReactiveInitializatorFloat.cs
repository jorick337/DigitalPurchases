using MyPackage.Tools.ReactiveProgramming;
using UnityEngine;

namespace MyPackage.Modules.Musics
{
    public class MusicReactiveInitializatorFloat : ReactiveInitializator<float>
    {
        [SerializeField] private bool _isSoundsVolume;

        private MusicManager _musicManager;

        public override void Init()
        {
            _musicManager = MusicManager.Instance;
            _reactiveVariable = _isSoundsVolume ? _musicManager.SoundsVolume : _musicManager.MusicVolume;

            base.Init();
        }
    }
}