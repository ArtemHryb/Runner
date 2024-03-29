using Scripts.Architecture.States.Interfaces;
using Scripts.Data;
using Scripts.UI;
using Scripts.UI.MainMenu;
using UnityEngine;

namespace Scripts.Architecture.Services.Factories
{
    public class UIFactory : IUIFactory
    {
        public Transform DistanceTracker { get; private set; }
        public Transform MagnetTracker { get; private set; }
        public Transform CoinView { get; private set; }
        public Transform HpBar { get; private set; }
        public Transform HudRoot { get; private set; }
        public MyCoroutineRunner CoroutineRunner { get; private set; }
        
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IAssetProvider _assetProvider;

        public UIFactory(IGameStateMachine gameStateMachine,IAssetProvider assetProvider)
        {
            _gameStateMachine = gameStateMachine;
            _assetProvider = assetProvider;
        }

        public MainMenuController CreateMainMenu()
        {
            CreateUIWindow(AssetPath.UICamera);
            MainMenuController menu = CreateUIWindow(AssetPath.MainMenu).
                GetComponent<MainMenuController>();
           return menu;
        }

        public void CreateInGameHud()
        {
            CreateHudRoot();
            CreatePregameWindow();
            CreateMagnetTracker();
            CreateDistanceTracker();
            CreateCoroutineRunner();
            CreateCoinView();
            CreateHpBar();
        }

        public Transform CreateUIWindow(string path, Transform parentTransform)
        {
            Transform window = Object.Instantiate(_assetProvider
                .Initialize<Transform>(path),parentTransform);
            
            return window;
        }

        public Transform CreateUIWindow(string path)
        {
            Transform window = Object.Instantiate(_assetProvider
                .Initialize<Transform>(path));
            
            return window;
        }

        public T CreateBaseWindow<T>(string path) where T : Component => 
            Object.Instantiate(_assetProvider.Initialize<T>(path));

        public void CreateMagnetTracker()
        {
            MagnetTracker = CreateUIWindow(AssetPath.MagnetTracker, HudRoot);
            MagnetTracker.gameObject.SetActive(false);
        }

        private void CreateHudRoot() => 
            HudRoot = Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.HUD));

        private void CreatePregameWindow() =>
            CreateUIWindow(AssetPath.PregameMenu, HudRoot);

        private void CreateCoinView() => 
            CoinView = CreateUIWindow(AssetPath.CoinCounter, HudRoot);

        private void CreateDistanceTracker() => 
            DistanceTracker = CreateUIWindow(AssetPath.DistanceTracker, HudRoot);

        private void CreateCoroutineRunner()
        {
            MyCoroutineRunner coroutineRunner = CreateBaseWindow<MyCoroutineRunner>(AssetPath.CoroutineRunner);
            CoroutineRunner = coroutineRunner;
        }

        private void CreateHpBar()
        {
            Transform hpBar = CreateUIWindow(AssetPath.HpBar,HudRoot);
            hpBar.GetComponent<HpBar>().Initialize(_gameStateMachine);
            HpBar = hpBar;
        }
    }
}