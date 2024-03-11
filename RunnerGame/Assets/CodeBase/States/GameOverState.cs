using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Services;
using CodeBase.UI.GameOverMenu;
using UnityEngine;

namespace CodeBase.States
{
    public class GameOverState : IState
    {
        private const string HUD = "Hud";
        private readonly IUIFactory _uiFactory;
        private readonly GameStateMachine _stateMachine;
        
        
        public GameOverState(GameStateMachine stateMachine,IUIFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
        }
        
        public void Exit()
        {
            
        }

        public void Enter()
        {
            CreateLoseMenu();
            Time.timeScale = 0f;
        }

        private void CreateLoseMenu()
        {
            Transform parent = GameObject.FindWithTag(HUD).transform;
            GameOverMenu loseWindow = _uiFactory.CreateBaseWindow(AssetPath.LoseWindow,parent).GetComponent<GameOverMenu>();
            loseWindow.Initialize(_stateMachine);
        }
    }
}