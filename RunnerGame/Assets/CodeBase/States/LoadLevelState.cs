using CodeBase.CameraLogic;
using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Hero;
using CodeBase.Logic.Spawners;
using CodeBase.SceneLoading;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.States
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private static readonly Vector3 GameCameraStartPosition = new (0.35f, 4.8f, -1.57f);
        private static readonly Vector3 GameCameraStartRotation = new (30f, 0f, 0f);
        private static readonly Vector3 PlayerStartPosition = new (0f, 0.28f, 0f);
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory, IUIFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        private void OnLoaded()
        {
            _gameFactory.CreateBaseGameObject(AssetPath.DirectionalLight, new Vector3(0f, 3f, 0f),
                Quaternion.Euler(50f, -30f, 0f), null);
            _gameFactory.CreateBaseGameObject(AssetPath.EventSystem, Vector3.zero, Quaternion.identity, null);
            Camera gameCamera = CreateGameCamera();
            Camera uiCamera = CreateUICamera();

            
            GameView hud = CreateHUD();   
            HpBar hpBar = CreateHpBar(hud.transform);
            hpBar.Initialize(_stateMachine);
          
            ChunkSpawner geometry = CreateGeometry();
            HeroMove hero = CreateHero();
            CameraFollow(gameCamera, hero);
            geometry.Initialize(hero.transform);
            
            hud.InputReporter.Initialize(uiCamera);
            hero.Initialize(hud.InputReporter);
            
        }
        public void Exit()
        {
        }

        private GameView CreateHUD() => 
            _uiFactory.CreateBaseWindow(AssetPath.HUD).GetComponent<GameView>();

        private HpBar CreateHpBar(Transform hud) => 
            _uiFactory.CreateBaseWindow(AssetPath.HpBar, hud.transform).GetComponent<HpBar>();

        private Camera CreateGameCamera() =>
            _gameFactory.CreateBaseGameObject(AssetPath.GameCamera, GameCameraStartPosition, 
                Quaternion.Euler(GameCameraStartRotation), null).GetComponent<Camera>();

        private ChunkSpawner CreateGeometry() => 
            _gameFactory.CreateBaseGameObject(AssetPath.Geometry, Vector3.zero, Quaternion.identity, null).GetComponent<ChunkSpawner>();

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