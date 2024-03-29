namespace Scripts.Architecture.States.Interfaces
{
    public interface IPayLoadedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}