using CodeBase.Factories;
using CodeBase.Factories.AssetProviding;
using CodeBase.SceneLoading;
using CodeBase.Services;
using CodeBase.Services.BestScore;
using CodeBase.Services.CoinService;

namespace CodeBase.States
{
    public class BootstrapState : IState
    {
        private const string BootScene = "Boot";
        private const string MainScene = "Main";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            
            RegisterServices();
        }
        
        public void Enter()
        {
            _sceneLoader.Load(BootScene, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadLevelState, string>(MainScene);

        private void RegisterServices()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<ICoinService>(new CoinService());
            _services.RegisterSingle<ISaveTheBestScore>(new SaveTheBestScore(_services.Single<ICoinService>()));
        }
    }
}