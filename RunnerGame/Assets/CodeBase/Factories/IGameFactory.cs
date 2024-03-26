using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Factories
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