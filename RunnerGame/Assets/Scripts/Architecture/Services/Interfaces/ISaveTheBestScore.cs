namespace Scripts.Architecture.Services.Interfaces
{
    public interface ISaveTheBestScore : IService
    {
        float TheBestScore { get; }
        void Save();
        void Load();
    }
}