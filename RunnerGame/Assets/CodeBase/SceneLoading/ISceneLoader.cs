using System;
using CodeBase.Services;

namespace CodeBase.SceneLoading
{
    public interface ISceneLoader : IService
    {
        void Load(string nextScene, Action onLoaded = null);
    }
}