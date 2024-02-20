using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Hero;
using CodeBase.SceneLoading;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.States
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        // private const string InitialPointTag = "InitialPoint";
        
        private static readonly Vector3 GameCameraStartPosition = new (0.35f, 8.14f, -1.57f);
        private static readonly Vector3 GameCameraStartRotation = new (30.12f, -1.44f, 0f);
        private static readonly Vector3 PlayerStartPosition = new (0.4f, 0.3f, 3f);
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        private void OnLoaded()
        { 
            // GameObject initialPoint = GameObject.FindWithTag(InitialPointTag);

            CreateGameCamera();
            Camera uiCamera = CreateUICamera();
            HeroMove hero = CreateHero();
            GameView gameView = CreateGameView();
            
            gameView.InputReporter.Initialize(uiCamera);
            hero.Initialize(gameView.InputReporter);
            
        }

        public void Exit()
        {
            
        }

        private void CreateGameCamera() =>
            _gameFactory.CreateBaseGameObject(AssetPath.GameCamera, GameCameraStartPosition, 
                Quaternion.Euler(GameCameraStartRotation), null);

        private GameView CreateGameView() => 
            _gameFactory.CreateBaseGameObject(AssetPath.GameView,Vector3.zero,
                Quaternion.identity,null).GetComponent<GameView>();

        private HeroMove CreateHero() => 
            _gameFactory.CreateBaseGameObject(AssetPath.Hero,PlayerStartPosition,
                Quaternion.identity,null).GetComponent<HeroMove>();

        private Camera CreateUICamera() =>
            _gameFactory.CreateBaseGameObject(AssetPath.UICamera,
                Vector3.zero, Quaternion.identity,null).GetComponent<Camera>();
    }
}