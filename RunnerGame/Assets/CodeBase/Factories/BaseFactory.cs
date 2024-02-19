using CodeBase.Factories.AssetProviding;
using UnityEngine;

namespace CodeBase.Factories
{
    public class BaseFactory : IBaseFactory
    {
        private readonly IAssetProvider _assetProvider;

        public BaseFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public GameObject CreateBaseGameObject(string path, Vector3 at, Quaternion rotation, Transform parent)
        {
            return Object.Instantiate(_assetProvider.Initialize<GameObject>(path), at, rotation, parent);
        }
    }
}