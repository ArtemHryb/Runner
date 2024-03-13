using CodeBase.SceneLoading;
using CodeBase.Services;
using CodeBase.Services.Audio;
using CodeBase.States;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;
        public IAudioService AudioService;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
        }
    }
}