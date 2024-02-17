using UnityEngine;

namespace CodeBase.Factories
{
    public interface IBaseFactory
    {
        GameObject CreateBaseGameObject(string path, Vector3 at,
            Quaternion rotation, Transform parent);
    }
}