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

        [SerializeField] private TMP_Text _currentDistanceText;
        [SerializeField] private TMP_Text _bestDistanceText;

        private IGameStateMachine _stateMachine;
        
        public void Initialize(IGameStateMachine stateMachine,float currentDistance,float bestDistance)
        {
            _stateMachine = stateMachine;
            _currentDistanceText.text = currentDistance.ToString("0.0" + "m");
            _bestDistanceText.text = bestDistance.ToString("0.0" + "m");
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