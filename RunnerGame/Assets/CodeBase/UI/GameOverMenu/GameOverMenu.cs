using CodeBase.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.GameOverMenu
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        [SerializeField] private TMP_Text _currentScoreText;
        [SerializeField] private TMP_Text _bestScoreText;

        private IGameStateMachine _stateMachine;
        
        public void Initialize(IGameStateMachine stateMachine,int currentScore,int bestScore)
        {
            _stateMachine = stateMachine;
            _currentScoreText.text = currentScore.ToString();
            _bestScoreText.text = bestScore.ToString();
        }
        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartButtonBehaviour);
            _mainMenuButton.onClick.AddListener(MainMenuButtonBehaviour);
        }

        private void MainMenuButtonBehaviour()
        {
            _stateMachine.Enter<MainMenuState>();
            Time.timeScale = 1f;
        }

        private void RestartButtonBehaviour()
        {
            _stateMachine.Enter<LoadGameState>();
            Time.timeScale = 1f;
        }
    }
}