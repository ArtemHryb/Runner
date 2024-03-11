using System;

namespace CodeBase.Services.CoinService
{
    public class CoinService : ICoinService
    {
        public event Action OnCoinPick;
        public int Count { get; set; }
        
        public void GetCoin(int count)
        {
            Count += count;
            OnCoinPick?.Invoke();
        }

        public void ResetCoin() => 
            Count = 0;
    }
}