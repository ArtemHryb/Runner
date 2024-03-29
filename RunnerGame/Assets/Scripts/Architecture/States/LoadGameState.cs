using Scripts.Architecture.Services.Factories;
using Scripts.Architecture.Services.Interfaces;
using Scripts.Architecture.States.Interfaces;
using Scripts.Audio;
using Scripts.Data;

namespace Scripts.Architecture.States
{
    public class LoadGameState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly ICoinService _coinService;
        private readonly IAudioService _audioService;
        private readonly IDistanceTrackerService _distanceTracker;

        public LoadGameState(ISceneLoader sceneLoader, IGameFactory gameFactory,
            IUIFactory uiFactory,ICoinService coinService, IAudioService audioService, IDistanceTrackerService distanceTracker)
        {
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