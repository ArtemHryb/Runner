using UnityEngine;

namespace CodeBase.Factories.AssetProviding
{
    public class AssetProvider : IAssetProvider
    {
        public T Initialize<T>(string path) where T : Object =>
            Resources.Load<T>(path);
    }
}