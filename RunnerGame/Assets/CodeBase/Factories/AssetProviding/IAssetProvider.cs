using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Factories.AssetProviding
{
    public interface IAssetProvider : IService
    {
        T Initialize<T>(string path) where T : Object;
    }
}