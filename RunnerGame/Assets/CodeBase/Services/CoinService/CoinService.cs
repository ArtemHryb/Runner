using System;
using CodeBase.Audio;
using CodeBase.Services.Audio;

namespace CodeBase.Services.CoinService
{
    public class CoinService : ICoinService
    {
        private readonly IAudioService _audioService;
        public event Action OnCoinPick;
        public int Count { get; set; }

        public CoinService(IAudioService audioService)
        {
            _audioService = audioService;
        }
        public void GetCoin(int count)
        {
            _audioService.PlaySfx(SfxType.PickCoin);
            Count += count;
            OnCoinPick?.Invoke();
        }

        public void ResetCoin() => 
            Count = 0;
    }
}