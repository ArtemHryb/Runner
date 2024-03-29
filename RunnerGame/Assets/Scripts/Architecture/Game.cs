using Scripts.Architecture.Services;
using Scripts.Architecture.Services.Interfaces;
using Scripts.Architecture.States;
using Scripts.Architecture.States.Interfaces;

namespace Scripts.Architecture
{
    public class Game
    {
        public readonly IGameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner) => 
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
    }
}