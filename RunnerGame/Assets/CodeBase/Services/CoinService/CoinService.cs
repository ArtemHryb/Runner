using System;
using System.IO;
using CodeBase.Audio;
using CodeBase.Services.Audio;
using UnityEngine;

namespace CodeBase.Services.CoinService
{
    public class CoinService : ICoinService
    {
        private readonly IAudioService _audioService;
        private readonly string _savePath = "Data/Coin.json";
        private readonly string _fileName = "CoinCount.json";
        public event Action OnCoinPick;
        public int Count { get; set; }

        public CoinService(IAudioService audioService)
        {
            _audioService = audioService;
            
        #if UNITY_ANDROID && !UNITY_EDITOR
            _savePath = Path.Combine(Application.persistentDataPath, _fileName);
        #else
            _savePath = Path.Combine(Application.dataPath, _fileName);
        #endif
        }

        public void GetCoin()
        {
            Count++;
            _audioService.PlaySfx(SfxType.PickCoin);
            OnCoinPick?.Invoke();
        }

        public void Save()
        {
            Data.CoinCount coinCount = new Data.CoinCount()
            {
                CoinsCount = Count
            };

            try
            {
                string json = JsonUtility.ToJson(coinCount, true);
                File.WriteAllText(_savePath,json);
            }
            catch (Exception)
            {
                Debug.Log("Save CoinCount problem");
            }
        }

        public void Load()
        {
            if (!File.Exists(_savePath))
                return;

            try
            {
                string json = File.ReadAllText(_savePath);

                Data.CoinCount coinCount = JsonUtility.FromJson<Data.CoinCount>(json);

                Count = coinCount.CoinsCount;
            }
            catch (Exception)
            {
                Debug.Log("Load CoinCount problem");
            }
        }
    }
}