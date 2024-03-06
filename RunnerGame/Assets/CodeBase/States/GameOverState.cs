using CodeBase.Data;
using CodeBase.Factories;
using UnityEngine;

namespace CodeBase.States
{
    public class GameOverState : IState
    {
        private readonly IUIFactory _uiFactory;
        
        
        public GameOverState(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public void Exit()
        {
            
        }

        public void Enter()
        {
            Debug.Log("Вы проиграли!!!!");
            CreateLoseMenu();
            //Time.timeScale = 0f;
        }

        private void CreateLoseMenu()
        {
            _uiFactory.CreateBaseWindow(AssetPath.LoseWindow);
        }
    }
}