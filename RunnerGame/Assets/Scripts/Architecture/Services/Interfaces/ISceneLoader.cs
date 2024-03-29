using System;

namespace Scripts.Architecture.Services.Interfaces
{
    public interface ISceneLoader : IService
    {
        void Load(string nextScene, Action onLoaded = null);
    }
}