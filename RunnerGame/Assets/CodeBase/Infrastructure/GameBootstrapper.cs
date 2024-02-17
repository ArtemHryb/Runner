using CodeBase.Factories;
using CodeBase.Factories.AssetProviding;
using CodeBase.SceneLoading;
using CodeBase.States;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private void Awake()
        {
            IBaseFactory factory = new BaseFactory(new AssetProvider());

            LoadGameState loadGameState = new LoadGameState(this, factory);
            loadGameState.Enter();
            
            DontDestroyOnLoad(this);
        }
    }
}
