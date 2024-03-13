﻿using CodeBase.States;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.MainMenu
{
    public class MainMenuModel
    {
        private const string MainScene = "Main";
        
        public void MoveToGameScene(GameStateMachine stateMachine) => 
            stateMachine.Enter<LoadLevelState,string>(MainScene);

        public void Exit() => 
            Application.Quit();

        public void UpdateBestScore(TMP_Text text, int score) => 
            text.text = score.ToString();
    }
}