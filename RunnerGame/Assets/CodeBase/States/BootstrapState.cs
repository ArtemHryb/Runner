﻿using CodeBase.Factories;
using CodeBase.Factories.AssetProviding;
using CodeBase.Logic;
using CodeBase.SceneLoading;
using CodeBase.Services;
using CodeBase.Services.Audio;
using CodeBase.Services.BestScore;
using CodeBase.Services.CoinService;

namespace CodeBase.States
{
    public class BootstrapState : IState
    {

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

        public void Enter() => 
            EnterMenu();

        private void EnterMenu() => 
            _stateMachine.Enter<MainMenuState>();

        public void Exit()
        {
        }


        private void RegisterServices()
        {
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));
            _services.RegisterSingle<IUIFactory>(new UIFactory(_services.Single<IGameStateMachine>(),
                _services.Single<IAssetProvider>()));
            _services.RegisterSingle<ISceneLoader>(new SceneLoader(_services.Single<ICoroutineRunner>()));
            _services.RegisterSingle<IAudioService>(new AudioService(_services.Single<IAssetProvider>(),
                _services.Single<IGameFactory>()));
            _services.RegisterSingle<ICoinService>(new CoinService(_services.Single<IAudioService>()));
            _services.RegisterSingle<IDistanceTrackerService>(new DistanceTrackerService(_services.Single<IUIFactory>()));
            _services.RegisterSingle<ISaveTheBestScore>(new SaveTheBestScore(_services.Single<IDistanceTrackerService>()));
        }
    }
}