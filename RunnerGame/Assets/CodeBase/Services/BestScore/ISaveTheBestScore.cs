namespace CodeBase.Services.BestScore
{
    public interface ISaveTheBestScore : IService
    {
        float TheBestScore { get; }
        void Save();
        void Load();
    }
}