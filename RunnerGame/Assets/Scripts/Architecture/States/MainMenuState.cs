using Scripts.Architecture.Services.Factories;
using Scripts.Architecture.Services.Interfaces;
using Scripts.Architecture.States.Interfaces;
using Scripts.Audio;
using Scripts.Data;
using Scripts.UI.MainMenu;

namespace Scripts.Architecture.States
{
    public class MainMenuState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;
        private readonly ISaveTheBestScore _saveTheBestScore;
        private readonly IAudioService _audioService;

        public MainMenuState(IGameStateMachine stateMachine,ISceneLoader sceneLoader,
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

        public void Enter() => 
            _sceneLoader.Load(AllTags.MenuScene, Initialize);

        private void Initialize()
        {
            _saveTheBestScore.Load();
           MainMenuController mainMenu = _uiFactory.CreateMainMenu();
           mainMenu.Initialize(_stateMachine,_saveTheBestScore,_audioService);
           _audioService.PlayMusic(MusicType.MainMenu);
        }
    }
}