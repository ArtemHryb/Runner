using CodeBase.Data;
using CodeBase.Factories.AssetProviding;
using CodeBase.SceneLoading;
using CodeBase.States;
using CodeBase.UI;
using CodeBase.UI.MainMenu;
using UnityEngine;

namespace CodeBase.Factories
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
            CreateDistanceTracker();
            CreateCoroutineRunner();
            CreateCoinView();
            CreateHpBar();
        }

        private void CreateHudRoot() => 
            HudRoot = Object.Instantiate(_assetProvider.Initialize<Transform>(AssetPath.HUD));

        private void CreatePregameWindow() =>
            CreateUIWindow(AssetPath.PregameMenu, HudRoot);

        private void CreateCoinView() => 
            CoinView = CreateUIWindow(AssetPath.CoinCounter, HudRoot);

        private void CreateDistanceTracker() => 
            DistanceTracker = CreateUIWindow(AssetPath.DistanceTracker, HudRoot);

        public void CreateMagnetTracker() => 
            MagnetTracker = CreateUIWindow(AssetPath.MagnetTracker, HudRoot);

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

        public Transform CreateUIWindow(string path, Transform parentTransform)
        {
            Transform window = Object.Instantiate(_assetProvider
                .Initialize<Transform>(path),parentTransform);
            
            return window;
        }

        public GameObject CreateBaseWindow(string path, Transform parentTransform)
        {
            Vector3 startPosition = new Vector3(0f, 0f, 0f);

            GameObject window = Object.Instantiate(_assetProvider
                .Initialize<GameObject>(path),parentTransform);
            
            window.transform.localPosition = startPosition;
            return window;
        }

        public GameObject CreateBaseWindow(string path, Transform parentTransform, Vector2 anchoredPosition)
        {
            GameObject window = Object.Instantiate(_assetProvider
                .Initialize<GameObject>(path),parentTransform);
            
            window.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
            
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
    }
}