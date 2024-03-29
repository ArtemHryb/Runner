using System;

namespace Scripts.Architecture.Services.Interfaces
{
    public interface ICoinService : IService
    {
        event Action OnCoinPick;
        int Count { get; set; }
        void GetCoin();
        void Save();
        void Load();
    }
}