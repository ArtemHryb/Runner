using CodeBase.States;
using TMPro;
using UnityEngine;

namespace CodeBase.UI.MainMenu
{
    public class MainMenuModel
    {
        public void MoveToGameScene(IGameStateMachine stateMachine) => 
            stateMachine.Enter<LoadGameState>();

        public void Exit() => 
            Application.Quit();

        public void UpdateBestScore(TMP_Text text, float score) => 
            text.text = score.ToString("0.0" +"m");
    }
}