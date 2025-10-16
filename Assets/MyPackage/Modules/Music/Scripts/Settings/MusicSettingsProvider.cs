using Cysharp.Threading.Tasks;
using MyPackage.Tools.LocalAddressables;
using UnityEngine;

namespace MyPackage.Modules.Musics
{
    public class MusicSettingsProvider : LocalAssetLoader
    {
        public async UniTask LoadAsync() => await LoadGameObjectAsync<GameObject>("MusicSettings");
    }
}