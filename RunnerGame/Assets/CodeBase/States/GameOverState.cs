﻿using CodeBase.Audio;
using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Logic;
using CodeBase.Services.Audio;
using CodeBase.Services.BestScore;
using CodeBase.Services.CoinService;
using CodeBase.UI.GameOverMenu;
using DG.Tweening.Core;
using UnityEngine;


namespace CodeBase.States
{
    public class GameOverState : IState
    {
        private readonly IUIFactory _uiFactory;
        private readonly ISaveTheBestScore _bestScore;
        private readonly IAudioService _audioService;
        private readonly IDistanceTrackerService _distanceTracker;

        private readonly ICoinService _coinService;
        private readonly IGameStateMachine _stateMachine;
        
        
        public GameOverState(IGameStateMachine stateMachine,IUIFactory uiFactory,
            ISaveTheBestScore bestScore,IAudioService audioService,ICoinService coinService,IDistanceTrackerService distanceTracker)
        {
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
            _bestScore = bestScore;
            _audioService = audioService;
            _coinService = coinService;
            _distanceTracker = distanceTracker;
        }
        
        public void Exit()
        {
        }

        public void Enter()
        {
            _bestScore.Save();
            _coinService.Save();
            
            RestartDoTween();
            DisableUiElements();
            
            _audioService.PlaySfx(SfxType.GameOver);
            _audioService.StopMusic();

            CreateLoseMenu();
        }

        private static void RestartDoTween() => 
            Object.Destroy(Object.FindObjectOfType<DOTweenComponent>().gameObject);

        private void DisableUiElements()
        {
            _uiFactory.CoinView.gameObject.SetActive(false);
            _uiFactory.HpBar.gameObject.SetActive(false);
            _uiFactory.DistanceTracker.gameObject.SetActive(false);
        }

        private void CreateLoseMenu()
        {
            _bestScore.Load();
            float besrScore = _bestScore.TheBestScore;
            float currentScore = _distanceTracker.Distance;
            GameOverMenu loseWindow = _uiFactory.CreateUIWindow(AssetPath.LoseWindow,_uiFactory.HudRoot)
                .GetComponent<GameOverMenu>();
           // loseWindow.Initialize(_stateMachine,currentScore,score);
            loseWindow.Initialize(_stateMachine,currentScore,besrScore);
            Time.timeScale = 0f;
        }
    }
}