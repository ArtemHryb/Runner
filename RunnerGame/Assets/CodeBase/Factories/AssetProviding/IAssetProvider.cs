using UnityEngine;

namespace CodeBase.Factories.AssetProviding
{
    public interface IAssetProvider
    {
        T Initialize<T>(string path) where T : Object;
    }
}