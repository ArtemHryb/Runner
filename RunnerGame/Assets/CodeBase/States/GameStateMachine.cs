﻿using System;
using System.Collections.Generic;
using CodeBase.Factories;
using CodeBase.Logic;
using CodeBase.Logic.Obstacle;
using CodeBase.SceneLoading;
using CodeBase.Services;
using CodeBase.Services.Audio;
using CodeBase.Services.BestScore;
using CodeBase.Services.CoinService;

namespace CodeBase.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type,IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader,services),
                
                [typeof(MainMenuState)] = new MainMenuState(this,sceneLoader, services.Single<IUIFactory>(),
                        services.Single<ISaveTheBestScore>(),services.Single<IAudioService>()),
                
                [typeof(LoadGameState)] = new LoadGameState(this,sceneLoader, services.Single<IGameFactory>(),
                    services.Single<IUIFactory>(),services.Single<ICoinService>(),
                    services.Single<IAudioService>(),services.Single<IDistanceTrackerService>()),
                
                [typeof(GameOverState)] = new GameOverState(this,services.Single<IUIFactory>(),
                    services.Single<ISaveTheBestScore>(),services.Single<IAudioService>()
                    ,services.Single<ICoinService>(),services.Single<IDistanceTrackerService>())
            };
        }
        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayLoadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            
            TState state = GetState<TState>();
            _activeState = state;
            
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}