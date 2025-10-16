using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace MyPackage.Tools.LocalAddressables
{
    public class LocalAssetLoader
    {
        protected List<Func<UniTask>> _onUnloaded = new();

        protected GameObject _currentCachedObject;
        protected GameObject _previousCachedObject;

        protected AsyncOperationHandle _currentHandle;
        protected AsyncOperationHandle _previousHandle;

        public async UniTask UnloadAllAsync()
        {
            await InvokeOnUnloaded();

            UnloadGameObjects();
            UnloadHandles();

            _onUnloaded.Clear();
        }

        protected async UniTask InvokeOnUnloaded()
        {
            if (_onUnloaded.Count == 0) return;

            await UniTask.WhenAll(_onUnloaded.Select(e => e()));
        }

        #region GAME OBJECT

        protected async UniTask<T> LoadGameObjectAsync<T>(string assetsId, Transform parent = null)
        {
            _previousCachedObject = _currentCachedObject;
            _currentCachedObject = await Addressables.InstantiateAsync(assetsId, parent).Task;

            return _currentCachedObject.GetComponent<T>();
        }

        protected void UnloadGameObjects()
        {
            ReleaseInstance(ref _currentCachedObject);
            ReleaseInstance(ref _previousCachedObject);
        }

        protected void ReleaseInstance(ref GameObject go)
        {
            if (go == null) return;

            if (go.activeInHierarchy)
                go.SetActive(false);

            Addressables.ReleaseInstance(go);
            _previousCachedObject = null;
        }

        #endregion

        #region OBJECT

        protected async UniTask<T> LoadObjectAsync<T>(string assetId)
        {
            _previousHandle = _currentHandle;
            _currentHandle = Addressables.LoadAssetAsync<T>(assetId);
            await _currentHandle.Task;

            return (T)_currentHandle.Result;
        }

        protected void UnloadHandles()
        {
            ReleaseHandle(ref _currentHandle);
            ReleaseHandle(ref _previousHandle);
        }

        protected void ReleaseHandle(ref AsyncOperationHandle handle)
        {
            if (handle.IsValid())
            {
                Addressables.Release(handle);
                handle = default;
            }
        }

        #endregion

        protected void AddEvent(Func<UniTask> onUnloadAction)
        {
            if (onUnloadAction != null)
                _onUnloaded.Add(onUnloadAction);
        }
    }
}