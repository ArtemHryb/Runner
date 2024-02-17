using System;

namespace CodeBase.SceneLoading
{
    public interface ISceneLoader
    {
        void Load(string nextScene, Action onLoaded = null);
    }
}