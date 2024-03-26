using CodeBase.Audio;
using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.SceneLoading;
using CodeBase.Services.Audio;
using CodeBase.Services.CoinService;

namespace CodeBase.States
{
    public class LoadGameState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly ICoinService _coinService;
        private readonly IAudioService _audioService;

        public LoadGameState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, IGameFactory gameFactory,
            IUIFactory uiFactory,ICoinService coinService, IAudioService audioService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _coinService = coinService;
            _audioService = audioService;
        }
        
        public void Enter() => 
            _sceneLoader.Load(AllTags.GameScene, InitGameWorld);

        private void InitGameWorld()
        {
            _audioService.PlayMusic(MusicType.Game);
            _uiFactory.CreateInGameHud();
            _gameFactory.CreateGameObjects();
            _coinService.ResetCoin();
        }
        public void Exit()
        {
        }
    }
}