using Cysharp.Threading.Tasks;
using MyPackage.Tools.LocalAddressables;
using UnityEngine;

namespace MyPackage.Modules.Levels.Loader
{
    public class LevelProvider : LocalAssetLoader
    {
        public async UniTask LoadAsync(int level) => await LoadGameObjectAsync<GameObject>($"Level{level}");
    }
}