using CodeBase.Audio;
using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Logic;
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
        private readonly IDistanceTrackerService _distanceTracker;

        public LoadGameState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, IGameFactory gameFactory,
            IUIFactory uiFactory,ICoinService coinService, IAudioService audioService, IDistanceTrackerService distanceTracker)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _coinService = coinService;
            _audioService = audioService;
            _distanceTracker = distanceTracker;
        }
        
        public void Enter() => 
            _sceneLoader.Load(AllTags.GameScene, InitGameWorld);

        private void InitGameWorld()
        {
            _audioService.PlayMusic(MusicType.Game);
            _uiFactory.CreateInGameHud();
            
            _coinService.Load();
            
            _distanceTracker.Reset();
            _distanceTracker.StartTracking();
            
            _gameFactory.CreateGameObjects();
        }
        public void Exit()
        {
        }
    }
}