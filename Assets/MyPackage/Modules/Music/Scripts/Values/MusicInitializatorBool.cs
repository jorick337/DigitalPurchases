using MyPackage.Tools.ReactiveProgramming;
using UnityEngine;

namespace MyPackage.Modules.Musics
{
    public class MusicInitializatorBool : ReactiveInitializator<bool>
    {
        [SerializeField] private bool _isSoundsVolume;

        public override void Init()
        {
            MusicManager musicManager = MusicManager.Instance;
            _reactiveVariable = _isSoundsVolume ? musicManager.IsSoundsActive : musicManager.IsMusicActive;

            base.Init();
        }
    }
}