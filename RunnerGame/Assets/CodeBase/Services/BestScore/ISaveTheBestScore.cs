namespace CodeBase.Services.BestScore
{
    public interface ISaveTheBestScore : IService
    {
        int TheBestScore { get; }
        void Save();
        void Load();
    }
}