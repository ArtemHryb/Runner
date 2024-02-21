using CodeBase.CameraLogic;
using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Hero;
using CodeBase.Logic;
using CodeBase.SceneLoading;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.States
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private static readonly Vector3 GameCameraStartPosition = new (0.35f, 4.8f, -1.57f);
        private static readonly Vector3 GameCameraStartRotation = new (30f, 0f, 0f);
        private static readonly Vector3 PlayerStartPosition = new (0f, 0.28f, -20f); //(0.4f, 0.3f, 3f);
        
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
            Camera gameCamera = CreateGameCamera();
            Camera uiCamera = CreateUICamera();
            CreateHud();
            
            ChunkSpawner geometry = CreateGeometry();
            HeroMove hero = CreateHero();
            CameraFollow(gameCamera, hero);
            geometry.Initialize(hero.transform);
            
            GameView gameView = CreateGameView();
            
            gameView.InputReporter.Initialize(uiCamera);
            hero.Initialize(gameView.InputReporter);
            
        }

        private ChunkSpawner CreateGeometry() => 
            _gameFactory.CreateBaseGameObject(AssetPath.Geometry, Vector3.zero, Quaternion.identity, null).GetComponent<ChunkSpawner>();

        public void Exit()
        {
            
        }

        private Camera CreateGameCamera() =>
            _gameFactory.CreateBaseGameObject(AssetPath.GameCamera, GameCameraStartPosition, 
                Quaternion.Euler(GameCameraStartRotation), null).GetComponent<Camera>();

        private GameView CreateGameView() => 
            _gameFactory.CreateBaseGameObject(AssetPath.GameView,Vector3.zero,
                Quaternion.identity,null).GetComponent<GameView>();

        private GameObject CreateHud() => 
            _gameFactory.CreateBaseGameObject(AssetPath.HUD, Vector3.zero, Quaternion.identity, null);

        private HeroMove CreateHero() => 
            _gameFactory.CreateBaseGameObject(AssetPath.Hero,PlayerStartPosition,
                Quaternion.identity,null).GetComponent<HeroMove>();

        private static void CameraFollow(Camera gameCamera, HeroMove hero) => 
            gameCamera.GetComponent<CameraFollow>().Follow(hero.gameObject);

        private Camera CreateUICamera() =>
            _gameFactory.CreateBaseGameObject(AssetPath.UICamera,
                Vector3.zero, Quaternion.identity,null).GetComponent<Camera>();
    }
}