using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Factories
{
    public interface IUIFactory : IService
    {
        void CreateMainMenu();
        GameObject CreateBaseWindow(string path, Transform parentTransform);
        GameObject CreateBaseWindow(string path);
    }
}