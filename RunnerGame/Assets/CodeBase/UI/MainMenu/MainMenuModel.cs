using CodeBase.States;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.MainMenu
{
    public class MainMenuModel
    {
        public void MoveToGameScene(IGameStateMachine stateMachine) => 
            stateMachine.Enter<LoadLevelState>();

        public void Exit() => 
            Application.Quit();

        public void UpdateBestScore(TMP_Text text, int score) => 
            text.text = score.ToString();
    }
}