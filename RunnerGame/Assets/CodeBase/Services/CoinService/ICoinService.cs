using System;

namespace CodeBase.Services.CoinService
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