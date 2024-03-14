using CodeBase.Audio;
using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.SceneLoading;
using CodeBase.Services.Audio;
using CodeBase.Services.BestScore;
using CodeBase.UI.MainMenu;

namespace CodeBase.States
{
    public class MainMenuState : IState
    {
        private const string BootScene = "Boot";

        private readonly GameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly ISaveTheBestScore _saveTheBestScore;
        private readonly IAudioService _audioService;

        public MainMenuState(GameStateMachine stateMachine,ISceneLoader sceneLoader,
            IUIFactory uiFactory,ISaveTheBestScore saveTheBestScore,IAudioService audioService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
            _saveTheBestScore = saveTheBestScore;
            _audioService = audioService;
        }
        
        public void Exit()
        {
            
        }

        public void Enter()
        {
            //_sceneLoader.Load(BootScene, Initialize);
            Initialize();
        }

        private void Initialize()
        {
            _saveTheBestScore.Load();
            _uiFactory.CreateBaseWindow(AssetPath.UICamera);
           MainMenuController mainMenu = _uiFactory.CreateBaseWindow(AssetPath.MainMenu, null).GetComponent<MainMenuController>();
           mainMenu.Initialize(_stateMachine,_saveTheBestScore,_audioService);
           _audioService.PlayMusic(MusicType.MainMenu);
        }
    }
}