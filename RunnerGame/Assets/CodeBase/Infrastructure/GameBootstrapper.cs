using CodeBase.SceneLoading;
using CodeBase.States;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            // IBaseFactory factory = new BaseFactory(new AssetProvider());
            // LoadGameState loadGameState = new LoadGameState(this, factory);
            // loadGameState.Enter();
            
            DontDestroyOnLoad(this);
        }
    }
}
