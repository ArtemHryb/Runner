using CodeBase.Audio;
using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Services.Audio;
using CodeBase.Services.BestScore;
using CodeBase.Services.CoinService;
using CodeBase.UI.GameOverMenu;
using UnityEngine;


namespace CodeBase.States
{
    public class GameOverState : IState
    {
        private readonly IUIFactory _uiFactory;
        private readonly ISaveTheBestScore _bestScore;
        private readonly IAudioService _audioService;
        private readonly ICoinService _coinService;
        private readonly IGameStateMachine _stateMachine;
        
        
        public GameOverState(IGameStateMachine stateMachine,IUIFactory uiFactory,
            ISaveTheBestScore bestScore,IAudioService audioService,ICoinService coinService)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _bestScore = bestScore;
            _audioService = audioService;
            _coinService = coinService;
        }
        
        public void Exit()
        {
        }

        public void Enter()
        {
            GameObject dotWeen = GameObject.Find("[DOTween]");
            if (dotWeen!= null) 
                Object.Destroy(dotWeen);

            _bestScore.Save();

            _audioService.PlaySfx(SfxType.GameOver);
            _audioService.StopMusic();

            CreateLoseMenu();

            Time.timeScale = 0f;
        }

        private void CreateLoseMenu()
        {
            _bestScore.Load();
            int score = _bestScore.TheBestScore;
            int currentScore = _coinService.Count;
            Transform parent = GameObject.FindWithTag(AllTags.HUD).transform;
            GameOverMenu loseWindow = _uiFactory.CreateBaseWindow(AssetPath.LoseWindow,parent).GetComponent<GameOverMenu>();
            loseWindow.Initialize(_stateMachine,currentScore,score);
        }
    }
}