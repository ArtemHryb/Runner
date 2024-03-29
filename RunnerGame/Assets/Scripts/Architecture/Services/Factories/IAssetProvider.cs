using Scripts.Architecture.Services.Interfaces;
using UnityEngine;

namespace Scripts.Architecture.Services.Factories
{
    public interface IAssetProvider : IService
    {
        T Initialize<T>(string path) where T : Object;
    }
}