using Scripts.Architecture.Services.Interfaces;
using Scripts.Architecture.States;
using UnityEngine;

namespace Scripts.Architecture
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        
        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}
