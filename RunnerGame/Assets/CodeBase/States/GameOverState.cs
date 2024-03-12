using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Services.BestScore;
using CodeBase.UI.GameOverMenu;
using UnityEngine;


namespace CodeBase.States
{
    public class GameOverState : IState
    {
        private const string HUD = "Hud";
        private readonly IUIFactory _uiFactory;
        private readonly ISaveTheBestScore _bestScore;
        private readonly GameStateMachine _stateMachine;
        
        
        public GameOverState(GameStateMachine stateMachine,IUIFactory uiFactory,ISaveTheBestScore bestScore)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _bestScore = bestScore;
        }
        
        public void Exit()
        {
            
        }

        public void Enter()
        {
            _bestScore.Save();
            
            CreateLoseMenu();
            Time.timeScale = 0f;
        }

        private void CreateLoseMenu()
        {
            _bestScore.Load();
            int score = _bestScore.TheBestScore;
            Transform parent = GameObject.FindWithTag(HUD).transform;
            GameOverMenu loseWindow = _uiFactory.CreateBaseWindow(AssetPath.LoseWindow,parent).GetComponent<GameOverMenu>();
            loseWindow.Initialize(_stateMachine,score);
        }
    }
}