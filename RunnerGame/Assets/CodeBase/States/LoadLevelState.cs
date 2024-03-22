using CodeBase.Audio;
using CodeBase.CameraLogic;
using CodeBase.Data;
using CodeBase.Factories;
using CodeBase.Hero;
using CodeBase.Logic.Obstacle;
using CodeBase.Logic.Spawners;
using CodeBase.SceneLoading;
using CodeBase.Services.Audio;
using CodeBase.Services.CoinService;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.States
{
    public class LoadLevelState : IState
    {
        private readonly Vector3 _gameCameraStartPosition = new (0.35f, 4.8f, -1.57f);
        private readonly Vector3 _gameCameraStartRotation = new (30f, 0f, 0f);
        private readonly Vector3 _playerStartPosition = new (0f, 0.28f, 0f);
        private readonly Vector2 _coinCounterAnchoredPosition = new(150f, -130f);
        
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private readonly ICoinService _coinService;
        private readonly IAudioService _audioService;

        public LoadLevelState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, IGameFactory gameFactory,
            IUIFactory uiFactory,ICoinService coinService, IAudioService audioService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
            _coinService = coinService;
            _audioService = audioService;
        }

        
        public void Enter() => 
            _sceneLoader.Load(AllTags.GameScene, InitGameWorld);


        private void InitGameWorld()
        {
            _audioService.PlayMusic(MusicType.Game);

            CreateDirectionalLight();
            CreateEventSystem();

            Camera gameCamera = CreateGameCamera();
            Camera uiCamera = CreateUICamera();
            GameView hud = CreateHUD();
            CreatePregameWindow(hud);

            HpBar hpBar = CreateHpBar(hud.transform);
            hpBar.Initialize(_stateMachine,_audioService);

            CoinsView coinCounter = CreateCoinView(hud);
            coinCounter.Initialize(_coinService);
            _coinService.ResetCoin();

            ChunkSpawner geometry = CreateGeometry();


            HeroMove hero = CreateHero();
            hud.InputReporter.Initialize(uiCamera);
            hero.Initialize(hud.InputReporter);
            CameraFollow(gameCamera, hero);
            geometry.Initialize(hero.transform);
        }

        public void Exit()
        {
        }

        private void CreateEventSystem() => 
            _gameFactory.CreateBaseGameObject(AssetPath.EventSystem, Vector3.zero, Quaternion.identity, null);

        private void CreateDirectionalLight() =>
            _gameFactory.CreateBaseGameObject(AssetPath.DirectionalLight, new Vector3(0f, 3f, 0f),
                Quaternion.Euler(50f, -30f, 0f), null);

        private GameView CreateHUD() => 
            _uiFactory.CreateBaseWindow(AssetPath.HUD).GetComponent<GameView>();

        private void CreatePregameWindow(GameView hud) => 
            _uiFactory.CreateBaseWindow(AssetPath.PregameMenu,hud.transform);

        private CoinsView CreateCoinView(GameView hud) => 
            _uiFactory.CreateBaseWindow(AssetPath.CoinCounter, hud.transform, _coinCounterAnchoredPosition).GetComponent<CoinsView>();

        private HpBar CreateHpBar(Transform hud) => 
            _uiFactory.CreateBaseWindow(AssetPath.HpBar, hud.transform).GetComponent<HpBar>();

        private Camera CreateGameCamera() =>
            _gameFactory.CreateBaseGameObject(AssetPath.GameCamera, _gameCameraStartPosition, 
                Quaternion.Euler(_gameCameraStartRotation), null).GetComponent<Camera>();

        private ChunkSpawner CreateGeometry() => 
            _gameFactory.CreateBaseGameObject(AssetPath.Geometry, Vector3.zero, Quaternion.identity, null).GetComponent<ChunkSpawner>();

        private HeroMove CreateHero() => 
            _gameFactory.CreateBaseGameObject(AssetPath.Hero,_playerStartPosition,
                Quaternion.identity,null).GetComponent<HeroMove>();

        private static void CameraFollow(Camera gameCamera, HeroMove hero) => 
            gameCamera.GetComponent<CameraFollow>().Follow(hero.gameObject);

        private Camera CreateUICamera() =>
            _gameFactory.CreateBaseGameObject(AssetPath.UICamera,
                Vector3.zero, Quaternion.identity,null).GetComponent<Camera>();
    }
}