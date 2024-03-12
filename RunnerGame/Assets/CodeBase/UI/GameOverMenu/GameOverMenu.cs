﻿using CodeBase.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.GameOverMenu
{
    public class GameOverMenu : MonoBehaviour
    {
        private const string MainScene = "Main";
        private const string Gamebootstrapper = "GameBootstrapper";

        [SerializeField] private Button _restartButton;
        [SerializeField] private TMP_Text _scoreText;

        private GameStateMachine _stateMachine;
        
        public void Initialize(GameStateMachine stateMachine,int score)
        {
            _stateMachine = stateMachine;
            _scoreText.text = score.ToString();
        }
        private void Awake()
        {
            _restartButton.onClick.AddListener(RestartButtonBehaviour);
        }

        private void RestartButtonBehaviour()
        {
            ClearScene();
            _stateMachine.Enter<LoadLevelState,string>(MainScene);
            Time.timeScale = 1f;
        }
        
        private void ClearScene()
        {
            GameObject[] allObjects = FindObjectsOfType<GameObject>();
            foreach (GameObject obj in allObjects)
            {
                if(obj == GameObject.Find(Gamebootstrapper))
                    return;
                else
                    Destroy(obj);
            }
        }
    }
}