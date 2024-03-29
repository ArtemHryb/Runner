using Scripts.Architecture.Services.Interfaces;

namespace Scripts.Architecture.States.Interfaces
{
    public interface IGameStateMachine : IService
    {
        void Enter<TState>() where TState : class, IState;
    }
}