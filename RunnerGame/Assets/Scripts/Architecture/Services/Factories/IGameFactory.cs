using Scripts.Architecture.Services.Interfaces;
using UnityEngine;

namespace Scripts.Architecture.Services.Factories
{
    public interface IGameFactory : IService
    {
        GameObject CreateBaseGameObject(string path, Vector3 at, Quaternion rotation, Transform parent);
        T CreateBaseGameObject<T>(string path) where T : Component;
        Transform Hero { get; }
        Camera Camera { get; }
        void CreateGameObjects();
    }
}