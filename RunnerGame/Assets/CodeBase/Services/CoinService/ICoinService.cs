using System;

namespace CodeBase.Services.CoinService
{
    public interface ICoinService : IService
    {
        event Action OnCoinPick;
        int Count { get; set; }
        void GetCoin(int count);
        void ResetCoin();
    }
}