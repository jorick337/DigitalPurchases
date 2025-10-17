using Cysharp.Threading.Tasks;
using MyPackage.Tools.LocalAddressables;
using UnityEngine;

namespace Game.Play.Welcome
{
    public class WelcomeProvider : LocalAssetLoader
    {
        public UniTask Load(int level) => LoadGameObjectAsync<GameObject>($"Welcome{level}");
    }
}


