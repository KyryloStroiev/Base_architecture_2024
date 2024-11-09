using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.View.Factory
{
    public class ViewFactory : IViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private readonly Vector3 _farAway = new Vector3(-999, 999, 0);

        public ViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }
        
        public GameObject InstantiateObject(Vector3 at, string pathPrefab)
        {
            GameObject prefab = _assetProvider.LoadAsset(pathPrefab);
            GameObject playerPrefab = _instantiator.InstantiatePrefabForComponent<GameObject>(
                prefab,
                at,
                Quaternion.identity,
                null);
            return playerPrefab;
        }
        
        public GameObject InstantiateObject(Vector3 at, GameObject prefab)
        {
            GameObject playerPrefab = _instantiator.InstantiatePrefabForComponent<GameObject>(
                prefab,
                at,
                Quaternion.identity,
                null);
            return playerPrefab;
        }

        public GameObject InstantiateObject(string pathPrefab)
        {
            GameObject prefab = _assetProvider.LoadAsset(pathPrefab);
            GameObject playerPrefab = _instantiator.InstantiatePrefabForComponent<GameObject>(
                prefab,
                _farAway,
                Quaternion.identity,
                null);
            return playerPrefab;
        }
    }
}