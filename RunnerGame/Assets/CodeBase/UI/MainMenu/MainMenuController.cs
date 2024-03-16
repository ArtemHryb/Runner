using CodeBase.Audio;
using CodeBase.Services.Audio;
using CodeBase.Services.BestScore;
using CodeBase.States;
using UnityEngine;

namespace CodeBase.UI.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private MainMenuView _mainMenuView;

        private IGameStateMachine _stateMachine;
        private ISaveTheBestScore _saveTheBestScore;
        private IAudioService _audioService;

        private MainMenuModel _mainMenuModel = new();

        public void Initialize(IGameStateMachine stateMachine,ISaveTheBestScore saveTheBestScore, IAudioService audioService)
        {
            _stateMachine = stateMachine;
            _saveTheBestScore = saveTheBestScore;
            _audioService = audioService;
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
            _audioService.PlaySfx(SfxType.Click);
            _mainMenuModel.MoveToGameScene(_stateMachine);
            Destroy(_mainMenuView.gameObject);
        }

        private void Exit()
        {
            _audioService.PlaySfx(SfxType.Click);
            _mainMenuModel.Exit();
        }
    }
}