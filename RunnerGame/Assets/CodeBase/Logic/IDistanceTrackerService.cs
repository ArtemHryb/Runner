using CodeBase.Services;

namespace CodeBase.Logic
{
    public interface IDistanceTrackerService : IService
    {
        float Distance { get; }
        void StartTracking();
        void Reset();
    }
}