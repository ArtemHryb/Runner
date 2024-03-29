namespace Scripts.Architecture.Services.Interfaces
{
    public interface IDistanceTrackerService : IService
    {
        float Distance { get; }
        void StartTracking();
        void Reset();
    }
}