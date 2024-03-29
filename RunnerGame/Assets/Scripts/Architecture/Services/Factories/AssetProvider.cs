using UnityEngine;

namespace Scripts.Architecture.Services.Factories
{
    public class AssetProvider : IAssetProvider
    {
        public T Initialize<T>(string path) where T : Object =>
            Resources.Load<T>(path);
    }
}