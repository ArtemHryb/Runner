using CodeBase.Services.BestScore;
using CodeBase.States;
using UnityEngine;

namespace CodeBase.UI.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private MainMenuView _mainMenuView;

        private GameStateMachine _stateMachine;
        private ISaveTheBestScore _saveTheBestScore;

        private MainMenuModel _mainMenuModel = new();

        public void Initialize(GameStateMachine stateMachine,ISaveTheBestScore saveTheBestScore)
        {
            _stateMachine = stateMachine;
            _saveTheBestScore = saveTheBestScore;
            InitInterface();
        }

        private void InitInterface()
        {
            _mainMenuView.PlayButton.onClick.AddListener(Play);
            _mainMenuView.ExitButton.onClick.AddListener(Exit);
            _mainMenuModel.UpdateBestScore(_mainMenuView.BestScore,_saveTheBestScore.TheBestScore);
        }

        private void Play()
        {
            _mainMenuModel.MoveToGameScene(_stateMachine);
            Destroy(_mainMenuView.gameObject);
        }

        private void Exit() => 
            _mainMenuModel.Exit();
    }
}